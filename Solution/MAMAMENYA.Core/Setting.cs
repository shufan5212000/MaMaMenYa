
using SharpArch.Core.DomainModel;

namespace MAMAMENYA.Core
{
    /// <summary>
    /// 系统设置表
    /// </summary>
    public class Setting : EntityBase<string>, IHasAssignedId<string>
    {
        /// <summary>
        /// 键值
        /// </summary>
        [FieldLength(1000)]
        public virtual string Value { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [FieldLength(4000)]
        public virtual string Type { get; set; }

        #region IHasAssignedId<string> 成员

        public virtual void SetAssignedIdTo(string assignedId)
        {
            this.Id = assignedId;
        }

        #endregion
    }


}
