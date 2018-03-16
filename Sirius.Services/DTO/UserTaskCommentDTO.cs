using Sirius.Data.BusinessObject;
using Sirius.Services.Manager;
using Sirius.Services.Manager.StaticManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Services.DTO
{
    public class UserTaskCommentDTO
    {
        public Guid UserTaskCommentId { get; set; }
        public Guid UserTaskId { get; set; }
        public string CommenterId { get; set; }
        public string CommenterName { get; set; }
        public string Comment { get; set; }
        public string CommentDate { get; set; }
        public string RelativeDateTime { get; set; }
        public DateTime Date { get; set; }
        public bool IsCommenter { get; set; }


        public static UserTaskCommentDTO Map(UserTaskCommentBO userTaskComment, IZeus zeus)
        {
            UserTaskCommentDTO self = new UserTaskCommentDTO
            {
                UserTaskCommentId = userTaskComment.Id,
                UserTaskId = userTaskComment.UserTaskId,
                CommenterId = userTaskComment.CommenterId,
                Comment = userTaskComment.Comment,
                CommentDate = DateExtension.ConvertDateToShort(userTaskComment.CommentDate),
                Date = userTaskComment.CommentDate,
                RelativeDateTime = userTaskComment.CommentDate.ToRelativeDate(),
            };
            self.CommenterName = userTaskComment.Commenter == null ? "" : userTaskComment.Commenter.FirstName + " " + userTaskComment.Commenter.LastName;

            return self;
        }

        public static IEnumerable<UserTaskCommentDTO> Map(IEnumerable<UserTaskCommentBO> userTaskComments, IZeus zeus)
        {
            List<UserTaskCommentDTO> selfs = new List<UserTaskCommentDTO>();
            foreach (UserTaskCommentBO userTaskComment in userTaskComments)
            {
                UserTaskCommentDTO self = UserTaskCommentDTO.Map(userTaskComment, zeus);
                selfs.Add(self);
            }
            return selfs;
        }

        public static UserTaskCommentDTO Map(UserTaskCommentBO userTaskComment, string currentUserId, IZeus zeus)
        {
            UserTaskCommentDTO self = new UserTaskCommentDTO
            {
                UserTaskCommentId = userTaskComment.Id,
                UserTaskId = userTaskComment.UserTaskId,
                CommenterId = userTaskComment.CommenterId,
                Comment = userTaskComment.Comment,
                CommentDate = DateExtension.ConvertDateToShort(userTaskComment.CommentDate),
                Date = userTaskComment.CommentDate,
                RelativeDateTime = userTaskComment.CommentDate.ToRelativeDate(),
                IsCommenter = userTaskComment.CommenterId == currentUserId
            };
            if (userTaskComment.Commenter != null)
                self.CommenterName = userTaskComment.CommenterId == currentUserId ? "You" : userTaskComment.Commenter.FirstName + " " + userTaskComment.Commenter.LastName;
            return self;
        }

        public static IEnumerable<UserTaskCommentDTO> Map(IEnumerable<UserTaskCommentBO> userTaskComments, string currentUserId, IZeus zeus)
        {
            List<UserTaskCommentDTO> selfs = new List<UserTaskCommentDTO>();
            foreach (UserTaskCommentBO userTaskComment in userTaskComments)
            {
                UserTaskCommentDTO self = UserTaskCommentDTO.Map(userTaskComment, currentUserId, zeus);
                selfs.Add(self);
            }
            return selfs;
        }
    }
}
