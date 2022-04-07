﻿using EventiaWebapp.Models;
using EventiaWebapp.Services.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Services
{
    public class EventiaUserHandler

    {
        private readonly EpicEventsContext _context;
        private readonly UserManager<EventiaUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public EventiaUserHandler(EpicEventsContext context, UserManager<EventiaUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// async function that gets a specefic EventiaUser
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>EventiaUser or null</returns>
        public async Task<EventiaUser> GetEventiaUser(string userId)
        {
            var user =  await _context.Users
                .FirstOrDefaultAsync(user => user.Id == userId);
            if (user == null) return null;
            return user;

        }

        /// <summary>
        /// Sets propperty SeeksOrganizerRole to true 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>bool true if database change is a success, false if not</returns>
        public async Task<bool> OrganizerAccountApplication(string userId)
        {
            var eventiaUser = await _context.Users
                .FirstOrDefaultAsync(user => user.Id == userId);

            if (eventiaUser == null) return false;

            eventiaUser.SeeksOrganizerRole = true;

            _context.Update(eventiaUser);
            await _context.SaveChangesAsync();
            return true;

            //TODO använd usermanager istället för context
        }
        /// <summary>
        /// Gets a list off all EveniaUsers applying for organizer roles
        /// </summary>
        /// <returns>List of Eventia Users or null</returns>
        public List<EventiaUser> GetSeeksOrganizers()
        {
            var usersSeekingOrganizerRole = _context.Users
                .Where(user => user.SeeksOrganizerRole == true)
                .ToList();

            if (usersSeekingOrganizerRole == null) return null;
            return usersSeekingOrganizerRole;

        }

        /// <summary>
        /// Gets a list off all EveniaUsers
        /// </summary>
        /// <returns>List of all Eventia Users or null</returns>
        ///
        public List<EventiaUser> GetEventiaUsers()
        {
            var eventiaUsers = _context.Users
                .ToList();

            if (eventiaUsers == null) return null;
            return eventiaUsers;
        }

        /// <summary>
        /// Adds the param UserId to Organizer role
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true if succes</returns>
        public async Task<bool> ApproveForOrganizerRole(string userId)
        {
           var eventiaUser = _context.Users
                .FirstOrDefault(user => user.Id == userId);

           if (eventiaUser == null) return false;

            //_userManager.RemoveFromRoleAsync(eventiaUser, "User");
            eventiaUser.SeeksOrganizerRole = false;
           await _userManager.AddToRoleAsync(eventiaUser, "Organizer");
            _context.Update(eventiaUser);
           await _context.SaveChangesAsync();

            //async?
            return true;
        }

    }
}
