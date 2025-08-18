using System.Collections.Generic;

namespace LightApplication.LightMessageInfo
{
    public class MessageInfo
    {
        public long MessageId { get; set; }
        public long ChatId{get;set;}
        public long SenderUserId { get; set; }
        public long Date { get; set; }//??
        public long EditDate { get; set; }//??

        public bool IsOutgoing { get; set; }

        public bool IsPinned { get; set; }

        public bool IsSendedOffline { get; set; }

        public bool CanBeSaved { get; set; }

        public MessageSendingState SendingState { get; set; }

        //about user
        public bool ContainsUnreadMention { get; set; }
    }

    public enum MessageSendingState
    {
        Pending,
        Failed,
        Sent
    };

    public class TextMessageInfo
    {
        public MessageInfo MessageInfo { get; set; }
        public TextContent MessageText { get; set; }
    }
    
    public class TextContent
    {
        public string Text { get; set; }
        public IEnumerable<FormattedFragmentDescriptor> TableOfFragments { get; set; }
    }

    public class FormattedFragmentDescriptor
    {
        public FormatType Format { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }
    }

    public enum FormatType
    {
        Mention,
        Hashtag,
        Bold,
        Italic,
        Url,
        Email,
        Phone,
        Code,
        Pre,
        TextUrl
    };

    /*
* 
message
{
sender_id = messageSenderUser { user_id = 633131869 }
scheduling_state = null


has_timestamped_media = true
is_channel_post = false
contains_unread_mention = false
date = 1546727914
edit_date = 0
forward_info = null
import_info = null
interaction_info = null
////////////////////////unread_reactions = vector[0] { }
fact_check = null
reply_to = null
message_thread_id = 0
topic_id = null
self_destruct_type = null
self_destruct_in = 0.000000
auto_delete_in = 0.000000
via_bot_user_id = 0
sender_business_bot_user_id = 0
sender_boost_count = 0
paid_message_star_count = 0
author_signature = ""
media_album_id = 0
effect_id = 0
has_sensitive_content = false
restriction_reason = ""
content = messageContactRegistered { }
reply_markup = null
}
    */
    

    //public class TextMessageContentInfo
    //{
    //    public bool IsEmpty { get; set; }
    //    public string TextContent { get; set; }
    //}
}
