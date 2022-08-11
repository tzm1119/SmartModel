namespace AuthGen
{
    /// <summary>
    /// 只生成UpdateDto和Command
    /// 
    /// 局部更新对象
    /// </summary>
    public class StaffPasswordModel : MetaModelDef
    {
        public StaffPasswordModel()
        {
            SetName(StaffPassword)
                .SetModuleName(Subjects)
                .SetDoNotGenDomainModel()
                .SetDoNotGenDto()
                .AddProperty(Guid(Id)
                    .ExistIn(UpdateDto))
                .AddProperty(String(Password)
                    .ExistIn(UpdateDto))
                .SupportPartialUpdate(Staff)
                ;
        }
    }
}
