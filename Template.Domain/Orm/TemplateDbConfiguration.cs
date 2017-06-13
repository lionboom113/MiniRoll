using System.Data.Entity;

namespace Template.Domain.Orm
{
    /// <summary>
    /// <para>DbContextのConfigクラス.</para>
    /// <para>同一アセンブリ内で自動検索してくれる.</para>
    /// <para>DbContextを複数設ける必要がある場合、DbContextの属性に以下を設定.</para>
    /// <para>[DbConfigurationType(typeof(TemplateDbConfiguration))]</para>
    /// </summary>
    public class TemplateDbConfiguration : DbConfiguration
    {
        public TemplateDbConfiguration()
        {
            //DbConnectionのインターセプターの追加
            AddInterceptor(new TemplateConnectionInterceptor());
        }
    }
}