using AutoMapper;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {

        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {         
            _unitOfWork = unitOfWork;
        }
       
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _unitOfWork.Notifications.GetNewNotificationsFor(userId);

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);

            //Manually Mapping

            //return notifications.Select(n => new NotificationDto() { 
            //      DateTime =n.DateTime,
            //      Gig = new GigDto
            //      {
            //          Artist = new UserDto
            //          {
            //              Id = n.Gig.Artist.Id,
            //              Name = n.Gig.Artist.Name
            //          },
            //          DateTime = n.DateTime,
            //          Id = n.Gig.Id,
            //          IsCanceled = n.Gig.IsCanceled,
            //          Venue = n.Gig.Venue
            //      },
            //      OriginalDateTime = n.OriginalDateTime,
            //      OriginalVenue = n.OriginalVenue,
            //      Type = n.Type
            //});
        }

        [HttpPost]
        public IHttpActionResult MarkIsRead()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _unitOfWork.UserNotifications.GetUserNotificationsFor(userId);

            notifications.ForEach(n => n.Read());

            return Ok();
                 
        }
    }
}
