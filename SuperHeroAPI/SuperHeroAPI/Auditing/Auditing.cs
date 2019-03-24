using SuperHeroAPI.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace SuperHeroAPI
{
    public class Auditing
    {
        private IAuditEventServices AuditEventsServices;
        private readonly SuperHeroAPIContext context;
        private readonly HttpContext _httpContext;
        private readonly int _entityId;

        public Auditing(HttpContext httpContext, int entityId)
        {
            context = new SuperHeroAPIContext();
            AuditEventsServices = new AuditEventServices(context);
            _httpContext = httpContext;
            _entityId = entityId;
        }

        public void RegisterAuditing()
        {
            AuditEvent auditEvent = new AuditEvent
            {
                Entity = GetEntity(),
                EntityId = _entityId,
                Datetime = DateTime.Now,
                Action = GetAction(),
                Username_Id = GetCurrentUserId()
            };
            AuditEventsServices.Create(auditEvent);


        }
        public string GetEntity()
        {
            return _httpContext.Request.RequestContext.RouteData.GetRequiredString("action");
        }

        public string GetAction()
        {
            return _httpContext.Request.RequestContext.HttpContext.Request.RequestType;
        }
        public int GetCurrentUserId()
        {
            var _userToken = _httpContext.GetOwinContext().Authentication.User;
            IEnumerable<Claim> claims = _userToken.Claims;
            return Convert.ToInt32(claims.Where(c => c.Type == ClaimTypes.Sid)
                     .Select(c => c.Value).SingleOrDefault());
        }
    }
}