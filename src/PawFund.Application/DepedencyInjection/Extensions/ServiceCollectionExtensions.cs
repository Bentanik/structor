﻿using PawFund.Application.Behaviors;
using PawFund.Application.Mapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PawFund.Application.DepedencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfigureMediatR(this IServiceCollection services)
        => services.AddMediatR(config => config.RegisterServicesFromAssembly(AssemblyReference.Assembly))
           .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
           .AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>))
           .AddValidatorsFromAssembly(Contract.AssemblyReference.Assembly, includeInternalTypes: true);


    public static IServiceCollection AddConfigurationAutoMapper(this IServiceCollection services)
        => services.AddAutoMapper(typeof(UserProfile));
}
