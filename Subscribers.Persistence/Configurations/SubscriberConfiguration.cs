using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscribers.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscribers.Persistence.Configuration
{
    public class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.Property(e => e.ClientId);
            builder.Property(e => e.ServiceId);
            builder.Property(e => e.ClientId);

            builder.Property(e => e.Active)
                .IsRequired();

            builder.Property(e => e.SubscribeDate);            
            builder.Property(e => e.UnsubscribeDate);
        }
    }
}
