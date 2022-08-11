using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartModel
{
    /// <summary>
    /// 局部更新数据 全局中心，用于保存局部更新对象之间的关系
    /// </summary>
    public class PartailUpdateCenter
    {
        static PartailUpdateCenter Ins { get; } =new PartailUpdateCenter();

        /// <summary>
        /// 注册局部更新关系
        /// </summary>
        public static void Regist(MetaModelDef metaModel)
        {
            Ins.Models.Add(metaModel);
        }

        /// <summary>
        ///  获取指定类型的 局部更新对象集合，如传进来的参数是 StaffModel，则返回值中包含
        ///  StaffPassword
        /// </summary>
        /// <param name="metaModel"></param>
        /// <returns></returns>
        public static IEnumerable<MetaModelDef> GetPartialUpdateModels(MetaModelDef metaModel)
        {
            return Ins._GetPartialUpdateModels(metaModel);
        }
        

        private IEnumerable<MetaModelDef> _GetPartialUpdateModels(MetaModelDef thisModel)
        {
            return Models.Where(m => m.PartialUpdateToThis(thisModel.ModelName));
        } 

        public HashSet<MetaModelDef> Models { get;  } = new();
    }
}
