using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NHibernate;
using SharpArch.Core.DomainModel;
using SharpArch.Data.NHibernate;

namespace MAMAMENYA.Core
{

    public class QueryBase : INotEntity
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        /// <summary>
        /// 例如" UserName desc,CreateTime asc"
        /// </summary>
        public string OrderBy { get; set; }
    }


    public interface IEntity
    {

    }
    public interface IInitialize
    {
        void InitializeData();

    }
    public interface INotEntity
    {

    }
    public interface IComponent : INotEntity
    {

    }

    [JsonObject]
    public abstract class ComponentBase : IComponent
    {
        [ScriptIgnore]
        [JsonIgnore]
        protected virtual ISession Session
        {
            get
            {
                string factoryKey = SessionFactoryAttribute.GetKeyFrom(this);
                return NHibernateSession.CurrentFor(factoryKey);
            }
        }
    }

    public class CRange<T> : Range<T>, IComponent
    {
        public CRange()
        {
        }
        public CRange(T start, T end)
            : base(start, end)
        {
        }
    }

    public interface IEntityCompositeIdBase : IEntity
    {
        /// <summary>
        /// 是否已经保存
        /// </summary>
        bool IsSaved { get; set; }
    }
    /// <summary>
    /// 多主键的基类
    /// </summary>
    public abstract class EntityCompositeIdBase : IEntityCompositeIdBase
    {
        /// <summary>
        /// 是否已经保存
        /// </summary>
        public virtual bool IsSaved { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        [XmlIgnore]
        protected virtual ISession Session
        {
            get
            {
                string factoryKey = SessionFactoryAttribute.GetKeyFrom(this);
                return NHibernateSession.CurrentFor(factoryKey);
            }
        }
    }


    public abstract class EntityBase : EntityBase<int>
    {

    }
    [JsonObject]
    public abstract class EntityBase<T> : EntityWithTypedId<T>, IInitialize, IEntity
    {

        [XmlElement("Id")]
        [ScriptIgnore]
        [JsonIgnore]
        public virtual T XmlId
        {
            get
            {
                return this.Id;
            }
            set
            { }
        }


        [ScriptIgnore]
        [JsonIgnore]
        [XmlIgnore]
        protected virtual ISession Session
        {
            get
            {
                string factoryKey = SessionFactoryAttribute.GetKeyFrom(this);
                return NHibernateSession.CurrentFor(factoryKey);
            }
        }

        //public virtual string Encrypt(string )

        //public virtual string Decrypt(string content,string salt)
        //{

        //}


        #region IInitialize 成员

        public virtual void InitializeData()
        {
            var item = this.Id;
        }

        #endregion
    }
}
