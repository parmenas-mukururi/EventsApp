using api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Database.EntityConfigs
{
    public class EventEntityConfig : IEntityTypeConfiguration<EventEntity>
    {
        public void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            builder.ToTable("Event");
            builder.HasKey(e => e.EventId);
            builder.Property(e => e.RowVersion);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.EventId).ValueGeneratedOnAdd();
            builder.HasIndex(e => e.EventId).IsClustered(false).IsUnique().HasDatabaseName("IX_Event_EventId");
        }
    }
}
