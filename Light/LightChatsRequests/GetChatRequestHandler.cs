using LightApplication.LightChatsRequests;
using System.Collections.Generic;
using TdApi = Telegram.Td.Api;

namespace Light.LightChatsRequests
{
    public class GetChatRequestHandler : GenericRequestHandler<ChatRequestResult>
    {
        protected override void SetInternalResult(TdApi.BaseObject @object)
        {
            var chat = @object as TdApi.Chat;

            _result = new ChatRequestResult
            {
                Id = chat.Id,
                Title = chat.Title,
                IsContainPhoto=false,
                UnreadCount=chat.UnreadCount,
                UnreadMentionCount=chat.UnreadMentionCount,
                UnreadReactionCount=chat.UnreadReactionCount
            };

            if (chat.LastMessage != null)
            {
                //_result.LastMessageTime = chat.LastMessage.Date;//проверить,а бывает ли lastMessage==null
                _result.IsOutgoingMessage = chat.LastMessage.IsOutgoing;
                _result.LastMessage = new MessageResult
                {
                    Id = chat.LastMessage.Id,
                    ChatId = chat.LastMessage.ChatId,
                    //SenderUserId=chat.MessageSenderId,
                    Date = chat.LastMessage.Date,
                    EditDate = chat.LastMessage.EditDate,
                    IsContainUnreadMentions = chat.LastMessage.ContainsUnreadMention,
                    MessageContent = GetLastMessageContent(chat.LastMessage.Content)
                };
            }

            if (chat.Photo != null)
            {
                _result.IsContainPhoto = true;

                _result.SmallPhotoId = chat.Photo.Small.Id;
                _result.SmallPhotoPath = chat.Photo.Small.Local.Path;

                _result.RealPhotoId = chat.Photo.Big.Id;
                _result.RealPhotoPath = chat.Photo.Big.Local.Path;
            }
        }

        private object GetLastMessageContent(TdApi.MessageContent content)
        {

            //if (message.IsOutgoing)
            //{
            //    lastMessageContentPreview = "Вы: ";
            //}
            
               
                ////case TdApi.MessageVideo video:
                ////    lastMessageContentPreview += "Видос";
                ////    break;
                ////case TdApi.MessageVoiceNote voiceNote:
                ////    lastMessageContentPreview += "Голосовуха";
                ////    break;
                ////case TdApi.MessageSticker sticker:
                ////    lastMessageContentPreview += $"Стикер: {sticker.Sticker}";
                ////    break;
                ////case TdApi.MessageAnimatedEmoji emoji://позже переработать
                ////    lastMessageContentPreview += $"Эмодзя: {emoji.Emoji}";
                ////    break;
                ////case TdApi.MessageDocument document:
                ////    lastMessageContentPreview += $"Документ: {document.Document.FileName}";
                ////    break;
                ////case TdApi.MessageCall call:
                ////    if (call.DiscardReason is TdApi.CallDiscardReasonMissed)
                ////    {
                ////        lastMessageContentPreview += "Пропущенный звонок";
                ////    }
                ////    else
                ////    {
                ////        lastMessageContentPreview += "Звонок";
                ////    }
                ////    break;

                ////case TdApi.MessagePinMessage pinnedMessage:
                ////        lastMessageContentPreview += "Закрепленное сообщение";
                ////    break;

                ////case TdApi.MessageVideoNote videoNote:
                ////        lastMessageContentPreview += "Видео сообщение";
                ////    break;

                ////case TdApi.MessageLocation location: 
                ////        lastMessageContentPreview += "Локация";
                ////    break;

                ////case TdApi.MessageContact contact: 
                ////        lastMessageContentPreview += "Контакт";
                ////    break;

            if(content is TdApi.MessageText text) 
                {

                var textContent = new TextContent
                {
                    Text = text.Text.Text
                };

                if (text.Text.Entities != null)
                {
                    var list = new List<FormattedFragmentDescriptor>();
                    textContent.TableOfFragments = list;

                    foreach (var item in text.Text.Entities)
                    {
                        var fmt = new FormattedFragmentDescriptor
                        {
                            Offset = item.Offset,
                            Length = item.Length
                        };

                        switch (item.Type)
                        {
                            case TdApi.TextEntityTypeBold b:
                                fmt.Format = FormatType.Bold;
                                break;
                            case TdApi.TextEntityTypeHashtag ht:
                                fmt.Format = FormatType.Hashtag;
                                break;
                        }

                        list.Add(fmt);
                    }
                }

                return textContent;
            }
            
            if(content is TdApi.MessagePhoto photo)
            {
                var photoContent = new PhotoContent
                {
                    IsSecret = photo.IsSecret,
                    Caption=new TextContent()
                };

                if(string.IsNullOrEmpty(photo.Caption.Text))
                {
                    photoContent.Caption.Text = "Photo";
                }
                else
                {
                    photoContent.Caption.Text = photo.Caption.Text;

                    if (photo.Caption.Entities != null)
                    {
                        var list = new List<FormattedFragmentDescriptor>();

                        foreach (var item in photo.Caption.Entities)
                        {
                            var fmt = new FormattedFragmentDescriptor
                            {
                                Offset = item.Offset,
                                Length = item.Length
                            };

                            switch (item.Type)
                            {
                                case TdApi.TextEntityTypeBold b:
                                    fmt.Format = FormatType.Bold;
                                    break;
                                case TdApi.TextEntityTypeHashtag ht:
                                    fmt.Format = FormatType.Hashtag;
                                    break;
                            }

                            list.Add(fmt);
                        }


                        photoContent.Caption.TableOfFragments = list;
                    }
                }

                if(photo.Photo.Minithumbnail != null && photo.Photo.Minithumbnail.Data != null && photo.Photo.Minithumbnail.Data.Count != 0)
                {
                    photoContent.HasMiniature = true;

                    photoContent.Miniature = new Miniature
                    {
                        Data = new byte[photo.Photo.Minithumbnail.Data.Count]
                    };

                    //for (int i=0;i< photo.Photo.Minithumbnail.Data.Count; i++)
                    //{
                    //    photoContent.Miniature.Data[i] = photo.Photo.Minithumbnail.Data[i];
                    //}
                    
                }

                return photoContent;
            }

            if (content is TdApi.MessageDocument document)
            {
                var documentContent = new DocumentContent
                {
                    Caption = new TextContent()
                };

                if (string.IsNullOrEmpty(document.Caption.Text))
                {
                    documentContent.Caption.Text = "Document";
                }
                else
                {
                    documentContent.Caption.Text = document.Caption.Text;

                    if (document.Caption.Entities != null)
                    {
                        var list = new List<FormattedFragmentDescriptor>();

                        foreach (var item in document.Caption.Entities)
                        {
                            var fmt = new FormattedFragmentDescriptor
                            {
                                Offset = item.Offset,
                                Length = item.Length
                            };

                            switch (item.Type)
                            {
                                case TdApi.TextEntityTypeBold b:
                                    fmt.Format = FormatType.Bold;
                                    break;
                                case TdApi.TextEntityTypeHashtag ht:
                                    fmt.Format = FormatType.Hashtag;
                                    break;
                            }

                            list.Add(fmt);
                        }

                        documentContent.Caption.TableOfFragments = list;
                    }
                }

                //if (photo.Photo.Minithumbnail != null && photo.Photo.Minithumbnail.Data != null && photo.Photo.Minithumbnail.Data.Count != 0)
                //{
                //    photoContent.HasMiniature = true;

                //    photoContent.Miniature = new Miniature();

                //    photoContent.Miniature.Data = new byte[photo.Photo.Minithumbnail.Data.Count];

                //    for (int i = 0; i < photo.Photo.Minithumbnail.Data.Count; i++)
                //    {
                //        photoContent.Miniature.Data[i] = photo.Photo.Minithumbnail.Data[i];
                //    }

                //}

                return documentContent;
            }

            return new UnknownStringContent
            {
                UnknownContent = $"[{content?.GetType().Name.Replace("Message", "")}]"
            };
        }
    }
}
