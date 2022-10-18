using allshop.api.Services.Contracts;
using allshop.api.Tools;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Text;

namespace allshop.api.Services
{
    public class GmailApiService: IGmailApiService
    {
        private string[] Scopes = { GmailService.Scope.MailGoogleCom };
        private string ApplicationName = "allshop";
        private readonly IConfiguration _configuration;

        public GmailApiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public GmailService GetService()
        {
            UserCredential credential;
            //using (var stream = new FileStream(Convert.ToString(_configuration["AppSettings:ClientInfo"]), FileMode.Open, FileAccess.Read))
           
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string FolderPath = Convert.ToString(_configuration["AppSettings:CredentialsInfo"]);
                string FilePath = Path.Combine(FolderPath, "token.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                      GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { GmailService.Scope.MailGoogleCom },
                    "user", CancellationToken.None, new FileDataStore(FilePath, true)).Result;
            }
            // Create Gmail API service.
            GmailService service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            return service;
        }

        public string MsgNestedParts(IList<MessagePart> Parts)
        {
            string str = string.Empty;
            if (Parts.Count() < 0)
            {
                return string.Empty;
            }
            else
            {
                IList<MessagePart> PlainTestMail = Parts.Where(x => x.MimeType == "text/plain").ToList();
                IList<MessagePart> AttachmentMail = Parts.Where(x => x.MimeType == "multipart/alternative").ToList();

                if (PlainTestMail.Count() > 0)
                {
                    foreach (MessagePart EachPart in PlainTestMail)
                    {
                        if (EachPart.Parts == null)
                        {
                            if (EachPart.Body != null && EachPart.Body.Data != null)
                            {
                                str += EachPart.Body.Data;
                            }
                        }
                        else
                        {
                            return MsgNestedParts(EachPart.Parts);
                        }
                    }
                }
                if (AttachmentMail.Count() > 0)
                {
                    foreach (MessagePart EachPart in AttachmentMail)
                    {
                        if (EachPart.Parts == null)
                        {
                            if (EachPart.Body != null && EachPart.Body.Data != null)
                            {
                                str += EachPart.Body.Data;
                            }
                        }
                        else
                        {
                            return MsgNestedParts(EachPart.Parts);
                        }
                    }
                }
                return str;
            }
        }
        public List<string> GetAttachments(string userId, string messageId, String outputDir)
        {
            try
            {
                List<string> FileName = new List<string>();
                GmailService GServices = GetService();
                Message message = GServices.Users.Messages.Get(userId, messageId).Execute();
                IList<MessagePart> parts = message.Payload.Parts;

                foreach (MessagePart part in parts)
                {
                    if (!String.IsNullOrEmpty(part.Filename))
                    {
                        string attId = part.Body.AttachmentId;
                        MessagePartBody attachPart = GServices.Users.Messages.Attachments.Get(userId, messageId, attId).Execute();

                        byte[] data = Base64ToByte(attachPart.Data);
                        File.WriteAllBytes(Path.Combine(outputDir, part.Filename), data);
                        FileName.Add(part.Filename);
                    }
                }
                return FileName;
            }
            catch (Exception e)
            {
             //   Console.WriteLine("An error occurred: " + e.Message);
                return null;
            }
        }
        public string Base64Decode(string Base64Test)
        {
            string EncodTxt = string.Empty;
            //STEP-1: Replace all special Character of Base64Test
            EncodTxt = Base64Test.Replace("-", "+");
            EncodTxt = EncodTxt.Replace("_", "/");
            EncodTxt = EncodTxt.Replace(" ", "+");
            EncodTxt = EncodTxt.Replace("=", "+");

            //STEP-2: Fixed invalid length of Base64Test
            if (EncodTxt.Length % 4 > 0) { EncodTxt += new string('=', 4 - EncodTxt.Length % 4); }
            else if (EncodTxt.Length % 4 == 0)
            {
                EncodTxt = EncodTxt.Substring(0, EncodTxt.Length - 1);
                if (EncodTxt.Length % 4 > 0) { EncodTxt += new string('+', 4 - EncodTxt.Length % 4); }
            }

            //STEP-3: Convert to Byte array
            byte[] ByteArray = Convert.FromBase64String(EncodTxt);

            //STEP-4: Encoding to UTF8 Format
            return Encoding.UTF8.GetString(ByteArray);
        }
        public byte[] Base64ToByte(string Base64Test)
        {
            string EncodTxt = string.Empty;
            //STEP-1: Replace all special Character of Base64Test
            EncodTxt = Base64Test.Replace("-", "+");
            EncodTxt = EncodTxt.Replace("_", "/");
            EncodTxt = EncodTxt.Replace(" ", "+");
            EncodTxt = EncodTxt.Replace("=", "+");

            //STEP-2: Fixed invalid length of Base64Test
            if (EncodTxt.Length % 4 > 0) { EncodTxt += new string('=', 4 - EncodTxt.Length % 4); }
            else if (EncodTxt.Length % 4 == 0)
            {
                EncodTxt = EncodTxt.Substring(0, EncodTxt.Length - 1);
                if (EncodTxt.Length % 4 > 0) { EncodTxt += new string('+', 4 - EncodTxt.Length % 4); }
            }

            //STEP-3: Convert to Byte array
            return Convert.FromBase64String(EncodTxt);
        }
        public void MsgMarkAsRead(string HostEmailAddress, string MsgId)
        {
            //MESSAGE MARKS AS READ AFTER READING MESSAGE
            ModifyMessageRequest mods = new ModifyMessageRequest();
            mods.AddLabelIds = null;
            mods.RemoveLabelIds = new List<string> { "UNREAD" };
            GetService().Users.Messages.Modify(mods, HostEmailAddress, MsgId).Execute();
        }

        public async Task<List<Gmail>> GetAllEmails()
        {
            try
            {
                GmailService GmailService =  GetService();
                string HostEmailAddress = Convert.ToString(_configuration["AppSettings:HostAddress"]);
                List<Gmail> EmailList = new List<Gmail>();
                UsersResource.MessagesResource.ListRequest ListRequest = GmailService.Users.Messages.List(HostEmailAddress);
                ListRequest.LabelIds = "INBOX";
                ListRequest.IncludeSpamTrash = false;
                ListRequest.Q = "is:unread"; //ONLY FOR UNDREAD EMAIL'S...

                //GET ALL EMAILS
                ListMessagesResponse ListResponse = ListRequest.Execute();

                if (ListResponse != null && ListResponse.Messages != null)
                {
                    //LOOP THROUGH EACH EMAIL AND GET WHAT FIELDS I WANT
                    foreach (Message Msg in ListResponse.Messages)
                    {
                        //MESSAGE MARKS AS READ AFTER READING MESSAGE
                        MsgMarkAsRead(HostEmailAddress, Msg.Id);

                        UsersResource.MessagesResource.GetRequest Message = GmailService.Users.Messages.Get(HostEmailAddress, Msg.Id);
                        //  Console.WriteLine("\n-----------------NEW MAIL----------------------");
                        // Console.WriteLine("STEP-1: Message ID:" + Msg.Id);

                        //MAKE ANOTHER REQUEST FOR THAT EMAIL ID...
                        Message MsgContent = Message.Execute();

                        if (MsgContent != null)
                        {
                            string FromAddress = string.Empty;
                            string Date = string.Empty;
                            string Subject = string.Empty;
                            string MailBody = string.Empty;
                            string ReadableText = string.Empty;

                            //LOOP THROUGH THE HEADERS AND GET THE FIELDS WE NEED (SUBJECT, MAIL)
                            foreach (var MessageParts in MsgContent.Payload.Headers)
                            {
                                if (MessageParts.Name == "From")
                                {
                                    FromAddress = MessageParts.Value;
                                }
                                else if (MessageParts.Name == "Date")
                                {
                                    Date = MessageParts.Value;
                                }
                                else if (MessageParts.Name == "Subject")
                                {
                                    Subject = MessageParts.Value;
                                }
                            }
                            //READ MAIL BODY
                            //  Console.WriteLine("STEP-2: Read Mail Body");
                            List<string> FileName = GetAttachments(HostEmailAddress, Msg.Id, Convert.ToString(_configuration["AppSettings:GmailAttach"]));

                            if (FileName.Count() > 0)
                            {
                                foreach (var EachFile in FileName)
                                {
                                    //GET USER ID USING FROM EMAIL ADDRESS-------------------------------------------------------
                                    string[] RectifyFromAddress = FromAddress.Split(' ');
                                    string FromAdd = RectifyFromAddress[RectifyFromAddress.Length - 1];

                                    if (!string.IsNullOrEmpty(FromAdd))
                                    {
                                        FromAdd = FromAdd.Replace("<", string.Empty);
                                        FromAdd = FromAdd.Replace(">", string.Empty);
                                    }
                                }
                            }
                            //else
                            //{
                            //    // Console.WriteLine("STEP-3: Mail has no attachments.");
                            //}

                            //READ MAIL BODY-------------------------------------------------------------------------------------
                            MailBody = string.Empty;
                            if (MsgContent.Payload.Parts == null && MsgContent.Payload.Body != null)
                            {
                                MailBody = MsgContent.Payload.Body.Data;
                            }
                            else
                            {
                                MailBody = MsgNestedParts(MsgContent.Payload.Parts);
                            }

                            //BASE64 TO READABLE TEXT--------------------------------------------------------------------------------
                            ReadableText = string.Empty;
                            ReadableText = Base64Decode(MailBody);

                            // Console.WriteLine("STEP-4: Identifying & Configure Mails.");

                            if (!string.IsNullOrEmpty(ReadableText))
                            {
                                Gmail GMail = new Gmail();
                                GMail.From = FromAddress;
                                GMail.Body = ReadableText;
                                GMail.MailDateTime = Convert.ToDateTime(Date);
                                EmailList.Add(GMail);
                            }
                        }
                    }
                }
                return EmailList;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex);

                return null;
            }
        }

        public async Task<GmailService> GetServiceGoogle()
        {
            UserCredential credential;

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string FolderPath = Convert.ToString(_configuration["AppSettings:CredentialsInfo"]);
                string FilePath = Path.Combine(FolderPath, "token.json");

                credential =  GoogleWebAuthorizationBroker.AuthorizeAsync(
                      GoogleClientSecrets.FromStream(stream).Secrets,
                    new[] { GmailService.Scope.MailGoogleCom },
                    "user", CancellationToken.None, new FileDataStore(FilePath, true)).Result;
            }

            //using (var stream = new FileStream(Convert.ToString(_configuration["AppSettings:ClientInfo"]), FileMode.Open, FileAccess.Read))
            //{                
            //    //string credPath = AppDomain.CurrentDomain.BaseDirectory;
            //    string FolderPath = Convert.ToString(_configuration["AppSettings:CredentialsInfo"]);
            //    string FilePath = Path.Combine(FolderPath, "token.json");
            //    credential =  GoogleWebAuthorizationBroker.AuthorizeAsync(
            //        GoogleClientSecrets.FromStream(stream).Secrets,
            //        new[] { GmailService.Scope.MailGoogleCom },
            //        "user",
            //        CancellationToken.None,
            //        new FileDataStore(FilePath, true)).Result;
            //}

            // Create Gmail API service.
            GmailService service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            return service;
        }

      
    }
}
