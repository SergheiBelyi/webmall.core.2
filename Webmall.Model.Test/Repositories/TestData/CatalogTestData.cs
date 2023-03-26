using System;
using System.Collections.Generic;
using System.Linq;
using Webmall.Model.Entities.Catalog;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Test.Repositories.TestData
{
    public class CatalogTestData
    {
        private readonly ICatalogRepository _catalogRepository;

        public CatalogTestData(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        private static List<WareListItem> _warelist;
        public List<WareListItem> WareList => _warelist ?? (_warelist = GenerateWareList());

        private static List<Ware> _wares;
        public List<Ware> Wares => _wares ?? (_wares = GenerateWares());

        private List<Ware> GenerateWares()
        {
            var result = new List<Ware>();
            var producers = _catalogRepository.GetProducers();

            for (int i = 0; i < 500; i++)
            {
                var prod = producers[i % producers.Count];
                Ware ware;
                result.Add(ware = new Ware
                {
                    Id = $"{i}",
                    Description = $"Ware description {i}",
                    Name = $"Фильтр масляный {prod.Name} {i}",
                    ProducerId = prod.Id,
                    ProducerName = prod.Name,
                    WareNumber = $"op525_{RandomString(Rnd.Next(25))}",
                    InAction = Rnd.Next(10) == 0,
                    IsNew = Rnd.Next(10) == 0,
                    IsSale = Rnd.Next(10) == 0,
                    MeasureUnit = "шт",
                });
                var imgCount = Rnd.Next(5);
                if (imgCount == 0) continue;
                ware.Images = new ImageInfo[imgCount];
                for (var img = 0; img < imgCount; img++)
                {
                    var imageId = Rnd.Next(8);
                    ware.Images[img] = new ImageInfo
                    {
                        Id = imageId.ToString(),
                        ImageUrl = $"/assets/images/media/product-main-promo-slider-{imageId}.jpg"
                    };
                }
            }

            return result;

        }

        public static readonly Random Rnd = new Random(1);
        private static readonly List<Group> StaticWareGroups = new List<Group>
        {
            new Group{ Id = "1", Name = "TestGroup1",
                SubGroups = new List<Group>{
                    new Group { Id = "6", Name = "TestGroup6", ParentId = "1" },
                    new Group { Id = "7", Name = "TestGroup7", ParentId = "1" },
                    new Group
                    {
                        Id = "8",
                        Name = "TestGroup8",
                        ParentId = "1",
                        SubGroups = TestCreateGroup(15, "8")
                    },
                    new Group
                    {
                        Id = "9",
                        Name = "TestGroup9",
                        ParentId = "1",
                        SubGroups = TestCreateGroup(50, "9")
                    }
                }},
            new Group
            {
                Id = "2",
                Name = "TestGroup2",
                SubGroups = new List<Group> { new Group { Id = "5", Name = "TestGroup5", ParentId = "2" } }
            },
            new Group
            {
                Id = "3",
                Name = "TestGroup3",
                SubGroups = new List<Group>{
                    new Group { Id = "6", Name = "TestGroup6", ParentId = "3" },
                    new Group { Id = "7", Name = "TestGroup7", ParentId = "3" },
                    new Group { Id = "8", Name = "TestGroup8", ParentId = "3",
                        SubGroups = TestCreateGroup(15, "8") },
                    new Group { Id = "9", Name = "TestGroup9", ParentId = "3",
                        SubGroups = TestCreateGroup(50, "9")  }
                }
            },
            new Group { Id = "4", Name = "TestGroup4" }

        };

        private List<WareListItem> GenerateWareList()
        {
            var result = new List<WareListItem>();
            var wares = Wares;

            for (var i = 0; i < wares.Count; i++)
            {
                result.Add(new WareListItem
                {
                    Id = wares[i].Id,
                    Availability = i % 15 == 0 ? ">5" : null,
                    Description = wares[i].Description,
                    Name = wares[i].Name,
                    Qnt = Rnd.Next(100),
                    ProducerId = wares[i].ProducerId,
                    ProducerName = wares[i].ProducerName,
                    WareNumber = wares[i].WareNumber,
                    IsAction = wares[i].InAction,
                    IsNew = wares[i].IsNew,
                    IsSale = wares[i].IsSale,
                    IsOriginal = wares[i].IsOriginal,
                    MeasureUnit = wares[i].MeasureUnit,
                    RetailPrice = Rnd.Next(1000),
                    HasImage = wares[i].HasImage,
                    ImageId = wares[i].Images?[0].Id.ToString() ?? "0",
                    ImageUrl = wares[i].Images?[0].ImageUrl
                });
            }

            return result;
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Rnd.Next(s.Length)]).ToArray());
        }

        private static List<Group> TestCreateGroup(int count, string parentId)
        {
            var list = new List<Group>();
            for (var i = 0; i < count; i++)
            {
                list.Add(new Group { Id = $"{parentId}{i}", Name = $"TestGroup{parentId}-{i}", ParentId = parentId, IconUrl = "http://88.99.96.122:8009/api/assets/autonovad/3ec1540f-9022-43e6-83de-53e72e8e3d9b/nocmsimage.jpg?version=0" });
            }
            return list;
        }

        public List<Group> WareGroups => StaticWareGroups;

        public List<Producer> Producers => _producers;
        private static List<Producer> _producers = new List<Producer>
        {
            new Producer {Id = "1", Name = "Test producer 1"},
            new Producer {Id = "2", Name = "Test producer 2"},
            new Producer {Id = "25", Name = "FILTRON"},
        };

        public List<GroupProperty> GroupProperties => _groupProperties;
        private static List<GroupProperty> _groupProperties = new List<GroupProperty>
        {
            new GroupProperty
            {
                Id = "1", Name = "Test property 1", Importance = 1,
                AvailableValues = new List<GroupPropertyAvailableValues>
                {
                    new GroupPropertyAvailableValues {Id = "1_1", Value = "Value 1_1"},
                    new GroupPropertyAvailableValues {Id = "1_2", Value = "Value 1_2"}
                }
            },
            new GroupProperty
            {
                Id = "2", Name = "Test property 2", Importance = 1,
                AvailableValues = new List<GroupPropertyAvailableValues>
                {
                    new GroupPropertyAvailableValues {Id = "2_1", Value = "Value 2_1"},
                    new GroupPropertyAvailableValues {Id = "2_2", Value = "Value 2_2"}
                }
            }
        };

        public List<WareProperty> WareProperties => _wareProperties;
        private static List<WareProperty> _wareProperties = new List<WareProperty>
            {
                new WareProperty { Value = "0W20", Name = "Класс вискозности SAE"},
                new WareProperty { Value = "60", Name = "Объем [л]"},
                new WareProperty { Value = "API SN", Name = "СПЕЦИФИКАЦИЯ"},
                new WareProperty { Value = "Barrel", Name = "Тип контейнера"},
                new WareProperty { Value = "Chrysler MS-6395", Name = "Рекомендации производителя масла"},
                new WareProperty { Value = "Daihatsu", Name = "Рекомендации производителя масла"},
                new WareProperty { Value = "Ford WSS-M2C 946-A", Name = "Рекомендации производителя масла"},
                new WareProperty { Value = "GM 6094 M", Name = "Рекомендации производителя масла"},
                new WareProperty { Value = "Honda", Name = "Рекомендации производителя масла"},
                new WareProperty { Value = "Hyundai", Name = "Рекомендации производителя масла"},
                new WareProperty { Value = "ILSAC GF-5", Name = "СПЕЦИФИКАЦИЯ"},
                new WareProperty { Value = "Isuzu", Name = "Рекомендации производителя масла"},
                new WareProperty { Value = "Kia", Name = "Рекомендации производителя масла"},
                new WareProperty { Value = "Mazda", Name = "Рекомендации производителя масла"},
                new WareProperty { Value = "Mitsubishi Dia Queen", Name = "Рекомендации производителя масла"},
                new WareProperty { Value = "Nissan", Name = "Рекомендации производителя масла"},
                new WareProperty { Value = "Subaru", Name = "Рекомендации производителя масла"},
                new WareProperty { Value = "Suzuki", Name = "Рекомендации производителя масла"},
                new WareProperty { Value = "Toyota", Name = "Рекомендации производителя масла"},
                new WareProperty { Value = "Бочка", Name = "Тип контейнера"}
            };

        // ReSharper disable once InconsistentNaming
    }
}