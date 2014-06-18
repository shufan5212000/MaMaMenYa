using System;
using System.IO;
using MAMAMENYA.Core;
using MAMAMENYA.Data.NHibernateMaps.Conventions;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Helpers;
using SharpArch.Data.NHibernate.FluentNHibernate;
using ForeignKeyConvention = MAMAMENYA.Data.NHibernateMaps.Conventions.ForeignKeyConvention;
using ManyToManyTableNameConvention = MAMAMENYA.Data.NHibernateMaps.Conventions.ManyToManyTableNameConvention;

namespace MAMAMENYA.Data.NHibernateMaps
{

    public class AutoMapConfig : FluentNHibernate.Automapping.DefaultAutomappingConfiguration
    {

        #region IAutomappingConfiguration ³ÉÔ±

        public AutoMapConfig()
        {

        }


        public override string GetComponentColumnPrefix(Member member)
        {
            return member.Name + "_";
        }
        public override bool ShouldMap(Member member)
        {

            if (member.IsProperty && member.IsPublic)
            {
                if (member.MemberInfo.GetCustomAttributes(typeof(NotMapAttribute), true).Length > 0)
                {
                    return false;
                }
            }

            return base.ShouldMap(member);
        }
        public override bool ShouldMap(Type type)
        {
            if (type.GetInterface(typeof(IEntity).Name) == null)
            {
                return false;
            }
            return base.ShouldMap(type);
        }

        //public string GetDiscriminatorColumn(Type type)
        //{
        //    throw new NotImplementedException();
        //}

        //public System.Collections.Generic.IEnumerable<FluentNHibernate.Automapping.Steps.IAutomappingStep> GetMappingSteps(AutoMapper mapper, IConventionFinder conventionFinder)
        //{
        //    throw new NotImplementedException();
        //}

        //public Type GetParentSideForManyToMany(Type left, Type right)
        //{
        //    throw new NotImplementedException();
        //}

        //public SubclassStrategy GetSubclassStrategy(Type type)
        //{
        //    throw new NotImplementedException();
        //}

        public override bool IsComponent(Type type)
        {
            return type.GetInterface(typeof(IComponent).Name) != null;
        }

        //public bool IsConcreteBaseType(Type type)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool IsDiscriminated(Type type)
        //{
        //    throw new NotImplementedException();
        //}

        public override bool IsId(Member member)
        {
            return member.Name == "Id" && member.PropertyType.IsValueType;
        }

        //public bool ShouldMap(Member member)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool ShouldMap(Type type)
        //{
        //    throw new NotImplementedException();
        //}

        //public string SimpleTypeCollectionValueColumn(Member member)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }

    public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
    {

        #region IAutoPersistenceModelGenerator Members

        public AutoPersistenceModel Generate()
        {

            var map = AutoMap.AssemblyOf<User>(new AutoMapConfig())
                .Conventions.Setup(GetConventions())
                .OverrideAll(c => c.IgnoreProperty("XmlId"))
                .UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();
            //.OverrideAll(c => c.IgnoreProperties(
            //    d => d.MemberInfo.GetCustomAttributes(typeof(NotMapAttribute), true).Length > 0
            //    ));
#if DEBUG
            string mapPath = "d:\\map";
            if (!Directory.Exists(mapPath))
            {
                Directory.CreateDirectory(mapPath);
            }

            map.WriteMappingsTo(mapPath);
#endif
            // 
            return map;

            //.Conventions.Add<CascadeConvention>();
            //var mappings = new AutoPersistenceModel();
            //mappings.AddEntityAssembly(typeof(Unit).Assembly).Where(GetAutoMappingFilter).OverrideAll(
            //    c => c.IgnoreProperty("XmlId")); ;
            //mappings.Conventions.Setup(GetConventions());
            //mappings.Setup(GetSetup());
            //mappings.IgnoreBase<Entity>();
            //mappings.IgnoreBase(typeof(EntityWithTypedId<>));
            //mappings.UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();


            ////FluentNHibernate.Automapping.AutoMap.AssemblyOf<Unit>(new AutoMapConfig());
            //mappings.WriteMappingsTo("d:\\map");
            //return mappings;

        }

        #endregion

        //private Action<AutoMappingExpressions> GetSetup()
        //{
        //    return c =>
        //    {
        //        c.FindIdentity = type => type.Name == "Id" && type.PropertyType.IsValueType;
        //        c.IsComponentType = type => type.GetInterface(typeof(IComponent).Name) != null;
        //        c.GetComponentColumnPrefix = type => type.Name + "_";


        //    };
        //}

        private Action<IConventionFinder> GetConventions()
        {
            return c =>
            {
                c.Add<ForeignKeyConvention>();
                c.Add<HasManyConvention>();
                c.Add<HasManyToManyConvention>();
                c.Add<ManyToManyTableNameConvention>();
                c.Add<PrimaryKeyConvention>();
                c.Add<ReferenceConvention>();
                c.Add<TableNameConvention>();
                c.Add<PropertyConvention>();
                c.Add(AutoImport.Never());

            };
        }

        /// <summary>
        /// Provides a filter for only including types which inherit from the IEntityWithTypedId interface.
        /// </summary>

        private bool GetAutoMappingFilter(Type t)
        {
            return t.GetInterface(typeof(IEntity).Name) != null;
            if (t.IsSubclassOf(typeof(Exception))) return false;
            //if (t.IsSubclassOf(typeof(INotEntity))) return false;
            if (t.GetInterface(typeof(IEntity).Name) != null) return false;
            return true;
            //return t.GetInterfaces().Any(x =>
            //                             x.IsGenericType &&
            //                             x.GetGenericTypeDefinition() == typeof(IEntityWithTypedId<>));
        }
    }
}
