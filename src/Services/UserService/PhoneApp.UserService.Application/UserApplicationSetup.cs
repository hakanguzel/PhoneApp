using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PhoneApp.UserService.Application.Users.Commands.CreateContact;
using PhoneApp.UserService.Application.Users.Commands.CreateUser;
using PhoneApp.UserService.Application.Users.Commands.DeleteContact;
using PhoneApp.UserService.Application.Users.Commands.DeleteUser;
using PhoneApp.UserService.Application.Users.Queries.GetUser;
using PhoneApp.UserService.Application.Users.Queries.ListUsers;
using System.Reflection;

namespace PhoneApp.UserService.Application
{
    public static class UserApplicationSetup
    {
        public static IServiceCollection AddUserServiceApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);

            #region Validators

            #region Users Validators
            services.AddTransient<IValidator<CreateContactCommand>, CreateContactCommandValidator>();
            services.AddTransient<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
            services.AddTransient<IValidator<DeleteContactCommand>, DeleteContactCommandValidator>();
            services.AddTransient<IValidator<DeleteUserCommand>, DeleteUserCommandValidator>();
            services.AddTransient<IValidator<GetUserQuery>, GetUserQueryValidator>();
            services.AddTransient<IValidator<ListUsersQuery>, ListUsersQueryValidator>();
            #endregion

            #endregion

            return services;
        }
    }
}
