# MyBots.Telegram.Activities


MyBots Telegram Bot activities are used to connect to Telegram application from UiPath application. In order to use these activities they must be placed or enclosed within "Telegram Connector Scope".

Pre-requisites - Telegram Bot must be created using BotFather and the user must have the Token in order to communicate with other groups or users.
Activities

    Telegram Connector scope
    Send Message
    Send Message Channel
    Send Image
    Send Image Channel
    Receive Message

Telegram Connector 

This is the parent activity within which all the below child activities Send Message, Send Image and Receive message can be executed.
  
        ApiKey- Api Key for your Telegram Bot. It's type is SecureString.
        Use Orchestrator to store credentials as your Asset and retrieve password in Robot as SecureString
        Example: 
            in Orchestrator: MyChatID = Login:MyRobot/Password: 123456789 (ApiKey as password)
            In UiPath Studuio: SecureString ChatID = UiPath.Core. Activities.GetRobotCredential(MyChatID)


Send Message

In this activity Telegram Bot sends messages instantly to users or public group where Telegram Bot is also one of the users(of type admin).

Input fields
    ChatID - To accept the Chat ID of private user or group. It's type is Int64.
        Example: ChatID = 123456789 (private user) or ChatID = -987654321
    Text message - To accept the message or string to deliver to user or group. It's type is String.
        Example: Text message = "Welcome to the world of Bots!!!"


Send Message to Channel

Same as "Send Message" activity, however it allows to send message to public user/group/channel by public nick (@telegramnick)

Input fields
    ChatID - To accept the Chat ID of Public user or group or channel. It's type is String.
        Example: ChatID = "@mytelname" (Public User) or ChatID = "@mytelchannle" (Public Channel)


Send Image

In this activity Telegram Bot sends image or picture instantly to users or group.
Input fields

    ChatID - To accept the Chat ID of user or group. It's type is Int64.
        Example: Chat ID = 123456789 (private user) or Chat ID = -987654321
    Image Path - To accept the physical location in computer where there the image exists. It's type is String.
        Example: Image Path = "D:\Images_Folder\test_image.png"
    Image Text - To accept a description for the attached image. When no value is given, by default value "Image sent from Bot" is given. It's type is String.
        Example: Image Text = "Nice picture!"


Send Image to Channel

Same as "Send Image" activity, however it allows to send image to public user/group/channel by public nick (@telegramnick)

Input fields
    ChatID - To accept the Chat ID of Public user or group or channel. It's type is String.
        Example: ChatID = "@mytelname" (Public User) or ChatID = "@mytelchannle" (Public Channel)


Get Updates

In this activity Telegram Bot receives the text messages sent by the private user and users in group.
Output fields

    Message List - Gives output of text messages in a list of strings. It's type is List<String>.
        Example: Message List = Msg_array (Variable Of type List of String)
