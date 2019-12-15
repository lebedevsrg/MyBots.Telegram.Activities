using System;
using System.Activities;
using System.ComponentModel;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using ServiceNow;

namespace Telegram
{
    [DisplayName("Send Message to Channel")]
    [Description("Sends message from Telegram Bot to user or group by nickname")]
    public sealed class SendMessageChannel : CodeActivity
    {

        // Define an activity input argument of type string
        [Category("Input")]
        [DisplayName("Channel Name")]
        [RequiredArgument]
        [Description("Enter Name of the Channel to which bot sends message")]
        public InArgument<string> Chat_ID { get; set; }

        // Define an activity input argument of type string
        [Category("Input")]
        [DisplayName("Text Message ")]
        [RequiredArgument]
        [Description("Enter message text to be delivered by bot")]
        public InArgument<string> Message_Text { get; set; }

        public SendMessageChannel()
        {
            this.Constraints.Add(ActivityConstraints.HasParentType<SendMessageChannel, TelegramConnector>(string.Format("Activity is valid only inside {0}", (object)typeof(TelegramConnector).Name)));
        }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.

        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            //string text = context.GetValue(this.Text);

            TelegramProp telegramDetails = (TelegramProp)context.DataContext.GetProperties()["telegramDetails"].GetValue(context.DataContext);

            var botToken = telegramDetails.authToken;

            var messageText = Message_Text.Get(context);

            if(messageText == null)
                throw new ArgumentException("Message text input is missing");

            var chatID_str = Chat_ID.Get(context);

  
            if (chatID_str == null)
                throw new ArgumentException("Channel name input is missing");

          
            var botClient = new TelegramBotClient(botToken);

            try
            {
                Message message = botClient.SendTextMessageAsync(chatID_str, messageText).GetAwaiter().GetResult();
            }

            catch (Telegram.Bot.Exceptions.ChatNotFoundException)
            {
                throw new Exception("Input Channel " + chatID_str+" does not exist");
            }
            catch (Telegram.Bot.Exceptions.ChatNotInitiatedException)
            {
                throw new Exception("Input Channel " + chatID_str+ " has not yet initiated a chat with bot yet");
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException)
            {
                throw new Exception("Input Bot Token - Represents an API error");
            }
            catch (System.Exception ex)
            {
                throw new Exception("Telegram Send Message Failed, Exception:"+ex.Message);
            }
            
        }

    }
}
