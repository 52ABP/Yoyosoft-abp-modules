using Senparc.Weixin.Containers;
using Senparc.Weixin.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YoYo.Containers
{
    /// <summary>
    /// 公众号信息Container
    /// </summary>
    /// <typeparam name="UserKeyType">用户唯一Id类型</typeparam>
    /// <typeparam name="TenantKeyType">租户唯一Id类型</typeparam>
    public class MpInfoContainer<UserKeyType, TenantKeyType> : BaseContainer<MpInfoBag>
    {
        /// <summary>
        /// 存储注册列表的KEY
        /// </summary>
        private const string REGIEST_LIST = "MP_REGIEST_LIST";

        /// <summary>
        /// 注册公众号信息
        /// </summary>
        /// <param name="key">获取公众号信息Key</param>
        /// <param name="appId">公众号AppId</param>
        /// <param name="appSecret">公众号AppSecret</param>
        /// <param name="token">公众号Token</param>
        /// <param name="encodingAESKey">公众号EncodingAESKey</param>
        /// <param name="name">公众号名称</param>
        /// <param name="userId">用户Id</param>
        /// <param name="tenantId">租户Id</param>
        public static void Register(string key, string appId, string appSecret, string token, string encodingAESKey, string name = null, UserKeyType userId = default(UserKeyType), TenantKeyType tenantId = default(TenantKeyType))
        {
            //记录注册信息，RegisterFunc委托内的过程会在缓存丢失之后自动重试
            RegisterFunc = () =>
            {
                //using (FlushCache.CreateInstance())
                //{
                var bag = new MpInfoBag()
                {
                    Key = key,
                    Name = name,
                    AppId = appId,
                    AppSecret= appSecret,
                    Token = token,
                    EncodingAESKey = encodingAESKey,
                };
                Update(key, bag, null);//第一次添加，此处已经立即更新
                return bag;
                //}
            };
            RegisterFunc();

            UpdateRegiestList(key, userId, tenantId);
        }

        /// <summary>
        /// 获取指定公众号信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static MpInfoBag TryGetMpInfo(string key)
        {
            if (!CheckRegistered(key))
            {
                throw new UnRegisterAppIdException(key, string.Format("此appId尚未注册，WechatTokenContainer.Register完成注册（全局执行一次即可）！"));
            }

            var mpInfoBag = TryGetItem(key);

            return mpInfoBag;
        }

        /// <summary>
        /// 获取所有注册信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="tenantId">租户Id</param>
        /// <returns></returns>
        public static IDictionary<string, MpInfoBag> GetAll(UserKeyType userId, TenantKeyType tenantId)
        {
            var registerList = Cache.Get<List<KeyInfo<UserKeyType, TenantKeyType>>>(REGIEST_LIST)
                .Where(info => info.UserId.Equals(userId) && info.TenantId.Equals(tenantId))
                .Select(info => info.Key)
                .ToList();
            IDictionary<string, MpInfoBag> dic = new Dictionary<string, MpInfoBag>();
            foreach (var key in registerList)
            {
                dic.Add(key, TryGetItem(key));
            }
            return dic;
        }

        /// <summary>
        /// 从缓存中删除指定项
        /// </summary>
        /// <param name="shortKey">获取公众号信息Key</param>
        /// <param name="userId">用户Id</param>
        /// <param name="tenantId">租户Id</param>
        public static void RemoveFromCache(string shortKey, UserKeyType userId, TenantKeyType tenantId)
        {
            Cache.RemoveFromCache(shortKey);
            var registerList = Cache.Get<List<KeyInfo<UserKeyType, TenantKeyType>>>(REGIEST_LIST)
                    .Where(info => info.UserId.Equals(userId) && info.TenantId.Equals(tenantId)).ToList();
            registerList.Remove(registerList.FirstOrDefault(info => info.Key == shortKey));
            Cache.Update(REGIEST_LIST, registerList);
        }

        /// <summary>
        /// 从缓存中删除指定项
        /// </summary>
        /// <param name="shortKey">获取公众号信息Key</param>
        public static new void RemoveFromCache(string shortKey)
        {
            RemoveFromCache(shortKey, default(UserKeyType), default(TenantKeyType));
        }

        private static void UpdateRegiestList(string key, UserKeyType userId, TenantKeyType tenantId)
        {
            if (Cache.CheckExisted(REGIEST_LIST, true))
            {
                var registerList = Cache.Get<List<KeyInfo<UserKeyType, TenantKeyType>>>(REGIEST_LIST);
                registerList.Add(new KeyInfo<UserKeyType, TenantKeyType> { Key = key, UserId = userId,TenantId = tenantId });
                Cache.Update(REGIEST_LIST, registerList);
            }
            else
            {
                var registerList = new List<KeyInfo<UserKeyType, TenantKeyType>>();
                registerList.Add(new KeyInfo<UserKeyType, TenantKeyType> { Key = key, UserId = userId, TenantId = tenantId });
                Cache.Set(REGIEST_LIST, registerList);
            }
        }
    }

    /// <summary>
    /// 公众号信息Container
    /// </summary>
    public class MpInfoContainer: MpInfoContainer<long, long>
    {

    }

    /// <summary>
    /// 公众号信息Bag
    /// </summary>
    public class MpInfoBag: BaseContainerBag, IBaseContainerBag_AppId
    {
        /// <summary>
        /// AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// AppSecret
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// EncodingAESKey
        /// </summary>
        public string EncodingAESKey { get; set; }
    }

    class KeyInfo<UserKeyType, TenantKeyType>
    {
        public string Key { get; set; }

        public UserKeyType UserId { get; set; }

        public TenantKeyType TenantId { get; set; }
    }
}
