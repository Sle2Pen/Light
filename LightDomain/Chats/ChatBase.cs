using System;
using System.Collections.Generic;
using System.Text;

namespace LightDomain.Chats
{
    //Уникальный ID чата
    //type
    //ChatType
    //Тип чата(
    //Private
    //,
    //Supergroup
    //и т.д.) polymorphism
    public class ChatBase
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public Photo Miniature { get; set; }
        public Photo MaxAvailablePhoto { get; set; }
        ////        Аватарка(
        ////small
        ////,
        ////big
        ////)
        //public Permissions ChatPermissions { get; set; }
        //////permissions
        //////ChatPermissions
        //////Права на отправку сообщений и т.д.

        //////last_message
        //////Message
        //////Последнее сообщение
        ////positions
        ////vector<ChatPosition>
        ////Где чат находится (Main, Archive и т.д.)
        ////default_disable_notification
        ////public bool 
        ////По умолчанию без уведомлений

        //public int UnreadMessagesCount { get; set; }
        //public long LastReadIncomingMessageId { get; set; }
        ////last_read_inbox_message_id
        ////long
        ////Последнее прочитанное входящее
        ////last_read_outbox_message_id
        ////long
        ////Последнее прочитанное исходящее
        //public long LastReadOutcomingMessageId { get; set; }
        ////        unread_mention_count
        ////int
        ////pinned_message_id
        ////long
        ////Закреплённое сообщение
        //public long PinnedMessageId { get; set; }//??
        //                                        //reply_markup_message_id
        //                                        //long
        //                                        //Сообщение с клавиатурой
        //public long ReplyMarkupMessageId { get; set; }
        ////draft_message
        ////DraftMessage
        ////Черновик
        //public Message Draft { get; set; }
        ////Непрочитанные упоминания
        //public int UnreadMentionsCount { get; set; }
        ////notification_settings
        ////ChatNotificationSettings
        ////Настройки уведомлений
        //public ChatNotificationSettings NotificationSettings { get; set; }

        ////client_data
        ////string//хер знает что
    }

    public class Photo
    {
        public long Id { get; set; }
        public string LocalPath { get; set; }
        public bool IsLoaded { get; set; }
    }
}
