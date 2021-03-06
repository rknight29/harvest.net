﻿using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial class HarvestRestClient
    {
        // https://github.com/harvesthq/api/blob/master/Sections/People.md

        /// <summary>
        /// List all users for the authenticated account. Makes a GET request to the People resource.
        /// </summary>
        /// <param name="updatedSince">An optional filter on the user updated-at property</param>
        public IList<User> ListUsers(DateTime? updatedSince = null)
        {
            var request = Request("people");

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            return Execute<List<User>>(request);
        }

        /// <summary>
        /// List all users for the authenticated account. Makes a GET request to the People resource.
        /// </summary>
        /// <param name="updatedSince">An optional filter on the user updated-at property</param>
        public async Task<IList<User>> ListUsersAsync(DateTime? updatedSince = null)
        {
            var request = Request("people");

            if (updatedSince != null)
                request.AddParameter("updated_since", updatedSince.Value.ToString("yyyy-MM-dd HH:mm"));

            // ReSharper disable once AsyncConverter.AsyncAwaitMayBeElidedHighlighting
            return await ExecuteAsync<List<User>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve a user on the authenticated account. Makes a GET request to the People resource.
        /// </summary>
        /// <param name="userId">The Id of the user to retrieve</param>
        public User User(long userId)
        {
            var request = Request("people/" + userId);

            return Execute<User>(request);
        }

        /// <summary>
        /// Retrieve a user on the authenticated account. Makes a GET request to the People resource.
        /// </summary>
        /// <param name="userId">The Id of the user to retrieve</param>
        public Task<User> UserAsync(long userId)
        {
            var request = Request("people/" + userId);

            return ExecuteAsync<User>(request);
        }

        /// <summary>
        /// Retrieve a user on the authenticated account. Makes a GET request to the People resource.
        /// </summary>
        /// <param name="email">The email address of the user to retrieve</param>
        public User User(string email)
        {
            var request = Request("people/" + email);

            return Execute<User>(request);
        }

        /// <summary>
        /// Retrieve a user on the authenticated account. Makes a GET request to the People resource.
        /// </summary>
        /// <param name="email">The email address of the user to retrieve</param>
        public Task<User> UserAsync(string email)
        {
            var request = Request("people/" + email);

            return ExecuteAsync<User>(request);
        }

        /// <summary>
        /// Creates a new user under the authenticated account. Makes both a POST and a GET request to the People resource.
        /// </summary>
        /// <param name="email">The user's email address</param>
        /// <param name="firstName">The user's first name</param>
        /// <param name="lastName">The user's last name</param>
        /// <param name="isActive">The status of the user</param>
        /// <param name="timezone">The user's timezone</param>
        /// <param name="isAdmin">Whether the user should be made an admin</param>
        /// <param name="telephone">The user's telephone number</param>
        /// <param name="department">The department the user belongs to</param>
        /// <param name="isContractor">Whether the user should be flagged as a contractor</param>
        /// <param name="hasAccessToAllFutureProjects">Whether the user should be automatically added to future projects created</param>
        /// <param name="wantsNewsletter">Whether the user should receive the newsletter</param>
        /// <param name="wantsWeeklyDigest">Whether the user should receive a weekly digest</param>
        /// <param name="defaultHourlyRate">The user's default hourly rate</param>
        /// <param name="costRate">The user's cost rate</param>
        public User CreateUser(string email, string firstName, string lastName, bool isActive = true, string timezone = null, bool? isAdmin = null, string telephone = null, string department = null, bool? isContractor = null, bool? hasAccessToAllFutureProjects = null, bool? wantsNewsletter = null, bool? wantsWeeklyDigest = null, decimal? defaultHourlyRate = null, decimal? costRate = null)
        {
            var options = GetCreateUserOptions(email, firstName, lastName, isActive, timezone, isAdmin, telephone, department, isContractor, hasAccessToAllFutureProjects, wantsNewsletter, wantsWeeklyDigest, defaultHourlyRate, costRate);

            return CreateUser(options);
        }

        /// <summary>
        /// Creates a new user under the authenticated account. Makes both a POST and a GET request to the People resource.
        /// </summary>
        /// <param name="email">The user's email address</param>
        /// <param name="firstName">The user's first name</param>
        /// <param name="lastName">The user's last name</param>
        /// <param name="isActive">The status of the user</param>
        /// <param name="timezone">The user's timezone</param>
        /// <param name="isAdmin">Whether the user should be made an admin</param>
        /// <param name="telephone">The user's telephone number</param>
        /// <param name="department">The department the user belongs to</param>
        /// <param name="isContractor">Whether the user should be flagged as a contractor</param>
        /// <param name="hasAccessToAllFutureProjects">Whether the user should be automatically added to future projects created</param>
        /// <param name="wantsNewsletter">Whether the user should receive the newsletter</param>
        /// <param name="wantsWeeklyDigest">Whether the user should receive a weekly digest</param>
        /// <param name="defaultHourlyRate">The user's default hourly rate</param>
        /// <param name="costRate">The user's cost rate</param>
        public Task<User> CreateUserAsync(string email, string firstName, string lastName, bool isActive = true, string timezone = null, bool? isAdmin = null, string telephone = null, string department = null, bool? isContractor = null, bool? hasAccessToAllFutureProjects = null, bool? wantsNewsletter = null, bool? wantsWeeklyDigest = null, decimal? defaultHourlyRate = null, decimal? costRate = null)
        {
            var options = GetCreateUserOptions(email, firstName, lastName, isActive, timezone, isAdmin, telephone, department, isContractor, hasAccessToAllFutureProjects, wantsNewsletter, wantsWeeklyDigest, defaultHourlyRate, costRate);

            return CreateUserAsync(options);
        }

        /// <summary>
        /// Creates a new user under the authenticated account. Makes a POST and a GET request to the People resource.
        /// </summary>
        /// <param name="options">The options for the new user to be created</param>
        public User CreateUser(UserOptions options)
        {
            var request = Request("people", RestSharp.Method.POST);

            request.AddBody(options);

            return Execute<User>(request);
        }

        /// <summary>
        /// Creates a new user under the authenticated account. Makes a POST and a GET request to the People resource.
        /// </summary>
        /// <param name="options">The options for the new user to be created</param>
        public Task<User> CreateUserAsync(UserOptions options)
        {
            var request = Request("people", RestSharp.Method.POST);

            request.AddBody(options);

            return ExecuteAsync<User>(request);
        }

        /// <summary>
        /// Delete a user from the authenticated account. Makes a DELETE request to the People resource.
        /// </summary>
        /// <param name="userId">The ID of the user to delete</param>
        public bool DeleteUser(long userId)
        {
            var request = Request("people/" + userId, RestSharp.Method.DELETE);

            var result = Execute(request);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Delete a user from the authenticated account. Makes a DELETE request to the People resource.
        /// </summary>
        /// <param name="userId">The ID of the user to delete</param>
        public async Task<bool> DeleteUserAsync(long userId)
        {
            var request = Request("people/" + userId, RestSharp.Method.DELETE);

            var result = await ExecuteAsync(request).ConfigureAwait(false);

            return result.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Toggle the Active status of a user on the authenticated account. Makes a POST request to the People/Toggle resource and a GET request to the People resource.
        /// </summary>
        /// <param name="userId">The ID of the user to toggle</param>
        public User ToggleUser(long userId)
        {
            var request = Request("people/" + userId + "/toggle", RestSharp.Method.POST);

            Execute(request);

            return User(userId);
        }

        /// <summary>
        /// Toggle the Active status of a user on the authenticated account. Makes a POST request to the People/Toggle resource and a GET request to the People resource.
        /// </summary>
        /// <param name="userId">The ID of the user to toggle</param>
        public async Task<User> ToggleUserAsync(long userId)
        {
            var request = Request("people/" + userId + "/toggle", RestSharp.Method.POST);

            await ExecuteAsync(request).ConfigureAwait(false);

            return await UserAsync(userId).ConfigureAwait(false);
        }

        /// <summary>
        /// Reset the password of a user on the authenticated account. Makes a POST request to the People/Reset_Password resource and a GET request to the People resource.
        /// </summary>
        /// <param name="userId">The ID of the user to reset</param>
        public User ResetPassword(long userId)
        {
            var request = Request("people/" + userId + "/reset_password", RestSharp.Method.POST);

            return Execute<User>(request);
        }

        /// <summary>
        /// Reset the password of a user on the authenticated account. Makes a POST request to the People/Reset_Password resource and a GET request to the People resource.
        /// </summary>
        /// <param name="userId">The ID of the user to reset</param>
        public Task<User> ResetPasswordAsync(long userId)
        {
            var request = Request("people/" + userId + "/reset_password", RestSharp.Method.POST);

            return ExecuteAsync<User>(request);
        }

        /// <summary>
        /// Update a user on the authenticated account. Makes a PUT and a GET request to the People resource.
        /// </summary>
        /// <param name="userId">The ID of the user to update</param>
        /// <param name="email">The user's email address</param>
        /// <param name="firstName">The user's first name</param>
        /// <param name="lastName">The user's last name</param>
        /// <param name="timezone">The user's timezone</param>
        /// <param name="isAdmin">Whether the user should be made an admin</param>
        /// <param name="telephone">The user's telephone number</param>
        /// <param name="department">The department the user belongs to</param>
        /// <param name="isContractor">Whether the user should be flagged as a contractor</param>
        /// <param name="hasAccessToAllFutureProjects">Whether the user should be automatically added to future projects created</param>
        /// <param name="wantsNewsletter">Whether the user should receive the newsletter</param>
        /// <param name="wantsWeeklyDigest">Whether the user should receive a weekly digest</param>
        /// <param name="defaultHourlyRate">The user's default hourly rate</param>
        /// <param name="costRate">The user's cost rate</param>
        public User UpdateUser(long userId, string email = null, string firstName = null, string lastName = null, string timezone = null, bool? isAdmin = null, string telephone = null, string department = null, bool? isContractor = null, bool? hasAccessToAllFutureProjects = null, bool? wantsNewsletter = null, bool? wantsWeeklyDigest = null, decimal? defaultHourlyRate = null, decimal? costRate = null)
        {
            var options = GetUpdateUserOptions(email, firstName, lastName, timezone, isAdmin, telephone, department, isContractor, hasAccessToAllFutureProjects, wantsNewsletter, wantsWeeklyDigest, defaultHourlyRate, costRate);

            return UpdateUser(userId, options);
        }
        
        /// <summary>
        /// Update a user on the authenticated account. Makes a PUT and a GET request to the People resource.
        /// </summary>
        /// <param name="userId">The ID of the user to update</param>
        /// <param name="email">The user's email address</param>
        /// <param name="firstName">The user's first name</param>
        /// <param name="lastName">The user's last name</param>
        /// <param name="timezone">The user's timezone</param>
        /// <param name="isAdmin">Whether the user should be made an admin</param>
        /// <param name="telephone">The user's telephone number</param>
        /// <param name="department">The department the user belongs to</param>
        /// <param name="isContractor">Whether the user should be flagged as a contractor</param>
        /// <param name="hasAccessToAllFutureProjects">Whether the user should be automatically added to future projects created</param>
        /// <param name="wantsNewsletter">Whether the user should receive the newsletter</param>
        /// <param name="wantsWeeklyDigest">Whether the user should receive a weekly digest</param>
        /// <param name="defaultHourlyRate">The user's default hourly rate</param>
        /// <param name="costRate">The user's cost rate</param>
        public Task<User> UpdateUserAsync(long userId, string email = null, string firstName = null, string lastName = null, string timezone = null, bool? isAdmin = null, string telephone = null, string department = null, bool? isContractor = null, bool? hasAccessToAllFutureProjects = null, bool? wantsNewsletter = null, bool? wantsWeeklyDigest = null, decimal? defaultHourlyRate = null, decimal? costRate = null)
        {
            var options = GetUpdateUserOptions(email, firstName, lastName, timezone, isAdmin, telephone, department, isContractor, hasAccessToAllFutureProjects, wantsNewsletter, wantsWeeklyDigest, defaultHourlyRate, costRate);

            return UpdateUserAsync(userId, options);
        }

        /// <summary>
        /// Updates a user on the authenticated account. Makes a PUT and a GET request to the People resource.
        /// </summary>
        /// <param name="userId">The ID for the user to update</param>
        /// <param name="options">The options to be updated</param>
        public User UpdateUser(long userId, UserOptions options)
        {
            var request = Request("people/" + userId, RestSharp.Method.PUT);

            request.AddBody(options);

            return Execute<User>(request);
        }

        /// <summary>
        /// Updates a user on the authenticated account. Makes a PUT and a GET request to the People resource.
        /// </summary>
        /// <param name="userId">The ID for the user to update</param>
        /// <param name="options">The options to be updated</param>
        public Task<User> UpdateUserAsync(long userId, UserOptions options)
        {
            var request = Request("people/" + userId, RestSharp.Method.PUT);

            request.AddBody(options);

            return ExecuteAsync<User>(request);
        }

        private static UserOptions GetUpdateUserOptions(string email, string firstName, string lastName, string timezone, bool? isAdmin, string telephone, string department, bool? isContractor, bool? hasAccessToAllFutureProjects, bool? wantsNewsletter, bool? wantsWeeklyDigest, decimal? defaultHourlyRate, decimal? costRate)
        {
            return new UserOptions
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Department = department,
                Telephone = telephone,
                Timezone = timezone,
                IsAdmin = isAdmin,
                IsContractor = isContractor,
                HasAccessToAllFutureProjects = hasAccessToAllFutureProjects,
                WantsNewsletter = wantsNewsletter,
                WantsWeeklyDigest = wantsWeeklyDigest,
                DefaultHourlyRate = defaultHourlyRate,
                CostRate = costRate
            };
        }

        private static UserOptions GetCreateUserOptions(string email, string firstName, string lastName, bool isActive, string timezone, bool? isAdmin, string telephone, string department, bool? isContractor, bool? hasAccessToAllFutureProjects, bool? wantsNewsletter, bool? wantsWeeklyDigest, decimal? defaultHourlyRate, decimal? costRate)
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));
            if (firstName == null)
                throw new ArgumentNullException(nameof(firstName));
            if (lastName == null)
                throw new ArgumentNullException(nameof(lastName));

            var options = new UserOptions
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Department = department,
                Telephone = telephone,
                Timezone = timezone,
                IsActive = isActive,
                IsAdmin = isAdmin,
                IsContractor = isContractor,
                HasAccessToAllFutureProjects = hasAccessToAllFutureProjects,
                WantsNewsletter = wantsNewsletter,
                WantsWeeklyDigest = wantsWeeklyDigest,
                DefaultHourlyRate = defaultHourlyRate,
                CostRate = costRate
            };

            return options;
        }
    }
}
