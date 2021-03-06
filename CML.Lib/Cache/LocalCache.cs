﻿using System;
using System.Collections;
using System.Web;

namespace CML.Lib.Cache
{
    /// <summary>
    /// Copyright (C) 2018 备胎 版权所有。
    /// 类名：LocalCache.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：本地缓存信息
    /// 创建标识：yjq 2018/1/4 16:36:49
    /// </summary>
    public sealed class LocalCache : ICache
    {
        /// <summary>
        /// 添加相对时间缓存
        /// </summary>
        /// <param name="key">需要添加缓存名称</param>
        /// <param name="obj">缓存值</param>
        /// <param name="isSlidCache">是否为相对时间</param>
        public void SimpleAddSlidingCache(string key, object obj, TimeSpan timeOutSpan)
        {
            if (string.IsNullOrWhiteSpace(key)) return;
            if (HttpRuntime.Cache[key] != null) SimpleRemoveCache(key);//如果原先存在则先移除
            HttpRuntime.Cache.Insert(key, obj, null, System.Web.Caching.Cache.NoAbsoluteExpiration, timeOutSpan);
        }

        /// <summary>
        /// 添加绝对时间缓存
        /// </summary>
        /// <param name="key">需要添加缓存名称</param>
        /// <param name="obj">缓存值</param>
        /// <param name="time">过期时间</param>
        public void SimpleAddAbsoluteCache(string key, object obj, DateTime time)
        {
            if (string.IsNullOrWhiteSpace(key)) return;

            if (HttpRuntime.Cache[key] != null) SimpleRemoveCache(key);//如果原先存在则先移除
            HttpRuntime.Cache.Insert(key, obj, null, time, System.Web.Caching.Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">需要获取的缓存名称</param>
        /// <returns></returns>
        public object SimpleGetCache(string key)
        {
            return SimpleIsExistCache(key) ? HttpRuntime.Cache[key] : null;
        }

        /// <summary>
        /// 判断缓存是否存在
        /// </summary>
        /// <param name="key">需要判断的缓存名称</param>
        /// <returns></returns>
        public bool SimpleIsExistCache(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return false;
            return HttpRuntime.Cache[key] == null ? false : true;
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">需要移除的缓存名称</param>
        public void SimpleRemoveCache(string key)
        {
            if (SimpleIsExistCache(key)) HttpRuntime.Cache.Remove(key);
        }

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public void SimpleRemoveAllCache()
        {
            System.Web.Caching.Cache _cache = HttpRuntime.Cache;
            IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                _cache.Remove(CacheEnum.Key.ToString());
            }
        }
    }
}