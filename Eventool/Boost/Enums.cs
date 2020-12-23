using System;
using System.Collections.Generic;
using System.Linq;

namespace Eventool.Boost
{
    public static class Enums
    {
        public enum MediaEntities : short { gallery, goods, news, promotions, reviews }
        public enum MediaType : short { image, video, audio }
        public enum Roles : short { Admin = 1, Platform, Organization, Visitor }
        public enum OperationTypes : short { Selling = 1, Registering, GettingOrder }
        public enum OrderStatus : short { Active, WaitingApprove, Delivered, Canceled_User, Canceled_Admin, Deleted }
        public enum SessionKeys : short { Cart = 1, Like, SMSCode, UserId }
        public enum Contents : short { ToDealers = 1 }
        public enum SortOrderBy : short { Status = 1 }
        public static class EnumUtil
        {
            public static IEnumerable<T> GetValues<T>()
            {
                return Enum.GetValues(typeof(T)).Cast<T>();

            }
        }
    }
}