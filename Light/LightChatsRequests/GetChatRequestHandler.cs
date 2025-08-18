using System;
using TdApi = Telegram.Td.Api;

namespace Light.LightChatsRequests
{
    public class GetChatRequestHandler : GenericRequestHandler<ChatRequestResult>
    {
        protected override void SetInternalResult(TdApi.BaseObject @object)
        {
            var chat = @object as TdApi.Chat;

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(chat.LastMessage.Date);
            DateTime dateTime = dateTimeOffset.UtcDateTime.ToLocalTime();

            _result = new ChatRequestResult
            {
                Id = chat.Id,
                Title = chat.Title,
                IsContainPhoto=false,
                LastMessageDate = dateTime.ToString("dd MMMMMMM"),
                LastMessageTime = dateTime.ToString("HH:mm")
            };

            if (chat.Photo != null)
            {
                _result.IsContainPhoto = true;

                _result.SmallPhotoId = chat.Photo.Small.Id;
                _result.SmallPhotoPath = chat.Photo.Small.Local.Path;

                _result.RealPhotoId = chat.Photo.Big.Id;
                _result.RealPhotoPath = chat.Photo.Big.Local.Path;
            }
        }

        private string GetLastMessagePreview(TdApi.Message message)
        {
            string lastMessageContentPreview = string.Empty;

            if (message.IsOutgoing)
            {
                lastMessageContentPreview = "Вы: ";
            }

            switch (message.Content)
            {
                case TdApi.MessageText text:
                    lastMessageContentPreview += text.Text.Text;
                    break;
                case TdApi.MessagePhoto photo:
                    lastMessageContentPreview += "Фотова";
                    break;
                case TdApi.MessageVideo video:
                    lastMessageContentPreview += "Видос";
                    break;
                case TdApi.MessageVoiceNote voiceNote:
                    lastMessageContentPreview += "Голосовуха";
                    break;
                case TdApi.MessageSticker sticker:
                    lastMessageContentPreview += $"Стикер: {sticker.Sticker}";
                    break;
                case TdApi.MessageAnimatedEmoji emoji://позже переработать
                    lastMessageContentPreview += $"Эмодзя: {emoji.Emoji}";
                    break;
                case TdApi.MessageDocument document:
                    lastMessageContentPreview += $"Документ: {document.Document.FileName}";
                    break;
                case TdApi.MessageCall call:
                    if (call.DiscardReason is TdApi.CallDiscardReasonMissed)
                    {
                        lastMessageContentPreview += "Пропущенный звонок";
                    }
                    else
                    {
                        lastMessageContentPreview += "Звонок";
                    }
                    break;

                case TdApi.MessagePinMessage pinnedMessage:
                        lastMessageContentPreview += "Закрепленное сообщение";
                    break;

                case TdApi.MessageVideoNote videoNote:
                        lastMessageContentPreview += "Видео сообщение";
                    break;

                case TdApi.MessageLocation location: 
                        lastMessageContentPreview += "Локация";
                    break;

                case TdApi.MessageContact contact: 
                        lastMessageContentPreview += "Контакт";
                    break;

                default:
                    lastMessageContentPreview += $"[{message.Content?.GetType().Name.Replace("Message", "")}]";
                    break;
            }

            return lastMessageContentPreview;
        }
    }
}
