// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using LightApplication.LightChatUpdater;
using LightApplication.LightLastChatMessageUpdater;
using LightApplication.LightMessageUpdater;
using NUnit.Framework;

namespace LightApplication.Tests
{
    //public class FakeChats:IChats
    //{
    //    public bool IsCalled { get; set; } = false;
    //}

    //public class FakeMessages:IMessages
    //{
    //    public bool IsCalled { get; set; } = false;
    //}

    /*
     updateNewChat
{
    chat = Chat
    {
        id = -1001234567890
        type = chatTypeSupergroup { 
            is_channel = false
            is_forum = false
            supergroup_id = 1234567890
        }
        title = "Моя группа"
        photo = chatPhoto {
            small = file { id = 123, ... }
            big = file { id = 124, ... }
        }
        order = 7205759403792793600
        is_pinned = false
        last_message = message { ... }  // последнее сообщение
        unread_count = 3
        last_read_inbox_message_id = 123456789
        last_read_outbox_message_id = 123456780
        unread_mention_count = 1
        notification_settings = chatNotificationSettings { ... }
        message_ttl = 0
        has_protected_content = false
        is_marked_as_unread = false
        is_blocked = false
        has_scheduled_messages = false
        can_be_deleted_only_for_self = true
        can_be_deleted_for_all_users = false
        can_be_reported = true
        default_disable_notification = false
        unread_reaction_count = 0
        restrictions = vector[0] {}
        permissions = chatPermissions { ... }
        slow_mode_delay = 0
        slow_mode_delay_expires_in = 0.000000
        client_data = ""
    }
}
         */


    /*updateChatLastMessage
{
    chat_id = -1001234567890
    last_message = message {
        id = 232760803328
        sender_id = messageSenderUser { user_id = 111518948 }
        chat_id = -1001234567890
        is_outgoing = false
        date = 1754995814
        edit_date = 0
        content = messageText {
            text = formattedText {
                text = "Привет!"
                entities = vector[0] {}
            }
        }
    }
    positions = vector[1] {
        chatPosition {
            list = chatListMain {}
            order = 7205759403792793600
            is_pinned = false
        }
    }
}
 */
    

    //public enum MessageContentType
    //{
    //    // === Основные типы ===
    //    Text,
    //    Photo,
    //    Video,
    //    Animation,           // GIF
    //    Audio,
    //    VoiceNote,
    //    Document,
    //    Sticker,
    //    VideoNote,           // Круговое видео

    //    // === Системные сообщения ===
    //    ChatCreated,
    //    ChatTitle,
    //    ChatPhoto,
    //    ChatDeletePhoto,
    //    ChatAddMembers,
    //    ChatJoinByLink,
    //    ChatDeleteMember,
    //    ChatUpgradeTo,
    //    ChatUpgradeFrom,
    //    PinMessage,
    //    Game,
    //    Call,
    //    Invoice,
    //    PaymentSuccessful,
    //    ContactRegistered,
    //    WebsiteConnected,
    //    WebApp,
    //    ChatSetTheme,
    //    ForumTopicCreated,
    //    ForumTopicEdited,
    //    ForumTopicIsClosedToggled,
    //    ForumTopicIsHiddenToggled,
    //    SuggestProfilePhoto,
    //    CustomServiceAction,
    //    GameScore,
    //    PaymentRefunded,
    //    PaymentRefundedToUser,
    //    PaymentSentToSeller,

    //    // === Взаимодействие ===
    //    ProximityAlertTriggered,
    //    Unsupported,
    //    LiveLocation,
    //    Contact,
    //    Location,
    //    Venue,
    //    Poll,
    //    Dice,
    //    ChatSetTtl,
    //    ScreenshotTaken,
    //    ChatShared,
    //    UserShared,
    //    ConnectedWebsite,
    //    ChatBackground,
    //    ForumTopic,
    //    Giveaway,
    //    GiveawayWinners,
    //    GiveawayCompleted,

    //    // === Бизнес и премиум ===
    //    PaidMedia,
    //    Story,
    //    MessageExpired,
    //    MessageAutoDeleteTimerChanged,

    //    //// === Специальные ===
    //    //SuggestProfilePhoto, // Уже есть выше, для примера
    //    //WebViewDataSent,
    //    //MessageFailedToSend, // Не в TDLib, но может быть в UI
    //}


    [TestFixture]
    public class ChatPreviewUpdaterTests
    {
        //[Test]
        //public void NewChatPreview_NewChatLastMessage_CallsChatsRepository()
        //{
        //    var fakeChats = new FakeChats();
        //    var fakeMessages = new FakeMessages();
        //    var chatMessagePreviewService = new ChatPreviewUpdater(fakeChats,fakeMessages);

        //    //chatMessagePreviewService.UpdatePreviewMessageWith();

        //    Assert.IsTrue(fakeChats.IsCalled);
        //}

        //[Test]
        //public void NewChatAdded()
        //{
        //    // TODO: Add your test code here
        //    var answer = 42;
        //    Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        //}
    }
}
