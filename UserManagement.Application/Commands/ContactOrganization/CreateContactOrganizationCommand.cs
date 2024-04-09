﻿namespace UserManagement.Application.Commands.ContactOrganization;

public sealed record CreateContactOrganizationCommand(AddContactOrganizationViewModel AddContactOrganizationViewModel)
    : IRequest<AddContactOrganizationViewModel>;