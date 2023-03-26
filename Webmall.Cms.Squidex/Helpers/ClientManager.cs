using System;
using System.Linq;
using System.Threading.Tasks;
using Squidex.ClientLibrary;
using Squidex.ClientLibrary.Management;
using Webmall.Cms.Squidex.Cms.Models;

namespace Webmall.Cms.Squidex.Helpers
{
    public class ClientManager
    {
        private SquidexClientManager _schema;
        private SquidexClientManager _app;

        public ClientManager(SquidexClientManager schema, SquidexClientManager app)
        {
            _schema = schema;
            _app = app;
        }
        public SquidexClientManager Schema => _schema;

        public SquidexClientManager App => _app;

        public AssetDto GetAsset(string slug)
        {
            try
            {
                var client = _schema.CreateAssetsClient();
                var image = Task.Run(() => client.GetAssetAsync(_schema.App, slug)).Result;
                return image;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public FileResponse GetAssetContent(string slug)
        {
            try
            {
                var client = _schema.CreateAssetsClient();
                var imageContent = Task.Run(() => client.GetAssetContentBySlugAsync(_schema.App, slug, "")).Result;
                return imageContent;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public TData GetSingle<TEntity, TData>(string schemaName = null)
                where TEntity : Content<TData>
                where TData : class, new()
        {
            try
            {
                var client = _schema.CreateContentsClient<TEntity, TData>(schemaName ?? typeof(TEntity).Name.ToLower());
                var data = Task.Run(() => client.GetAsync()).Result?.Items?[0]?.Data;
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public TData[] Get<TEntity, TData>(string schemaName = null)
                where TEntity : Content<TData>
                where TData : class, new()
        {
            try
            {
                var data = GetListItems<TEntity, TData>(schemaName);
                var result = (typeof(TData).IsSubclassOf(typeof(CmsItemEntity))
                    ? data?.Items?.Select(i =>
                    {
                        (i.Data as CmsItemEntity).ItemId = i.Id;
                        return i.Data;
                    })
                    : data?.Items?.Select(i => i.Data)
                    ).ToArray();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ContentsResult<TEntity, TData> GetListItems<TEntity, TData>(string schemaName, string filter = null)
            where TEntity : Content<TData> where TData : class, new()
        {
            var client = _schema.CreateContentsClient<TEntity, TData>(schemaName ?? typeof(TEntity).Name.ToLower());
            var data = Task.Run(() => client.GetAsync(new ContentQuery
            {
                Filter = filter
            })).Result;
            return data;
        }

        public void Update<TEntity, TData>(string schemaName, TEntity entity)
            where TEntity : Content<TData> where TData : class, new()
        {
            var client = _schema.CreateContentsClient<TEntity, TData>(schemaName ?? typeof(TEntity).Name.ToLower());
            Task.Run(() => client.UpdateAsync(entity));
        }
    }
}
