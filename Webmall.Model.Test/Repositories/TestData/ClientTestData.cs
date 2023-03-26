using System;
using System.Collections.Generic;
using Webmall.Model.Entities.Client;

namespace Webmall.Model.Test.Repositories.TestData
{
    public class ClientTestData
    {
        public List<Client> Clients => _clients;
        private static readonly List<Client> _clients = new List<Client> {
                new Client {
                    Id = "100006",
                    Code = "111111",
                    Name = "Test name client 1",
                    CurrentWarehouseId = "1",
                    CanPayByCard = false,
                    CanPayByCash = false,
                    ShowTaxInvoiceDelivery = false,
                    DefaultTaxInvoiceDelivery = false,
                    IsRetail = false,
                    IsOrganizationManager = false,
                    IsCustomer = false,
                    IsSupplier = false,
                    ManagerData = new ManagerData {Email = "testManageremail1@itworks.com"},
                    IsDeliveryEnabled = false,
                    CurrentValute = "BLR",
                    IsOperative = false,
                    AllowCustomOrders = false,
                    Contracts = new List<Contract>
                    {
                        new Contract
                        {
                            Id = "100006-1", Name = "Contract 1 Prepay", Description = "Contract 1 description",
                            PayDelayDays = 0, PayDelayName = "Prepay"
                        },
                        new Contract
                        {
                            Id = "100006-2", Name = "Contract 2", Description = "Contract 2 description", MaxSum = 100000,
                            PayDelayDays = 10, PayDelayName = "Pay Delay 10"
                        }
                    },
                    Contacts = new List<Contact>
                    {
                        new Contact
                        {
                            Id = "100006-1", Name = "Contact Person 1", Comment = "Simple contact", DateFrom = DateTime.Today.AddDays(-1), Phone = "011111111111"
                        },
                        new Contact
                        {
                            Id = "100006-2", Name = "Contact Person 2", Comment = "Trasted contact", DateFrom = DateTime.Today.AddDays(-1), DateTo = DateTime.Today.AddMonths(1),
                            Phone = "022222222222", DocumentNumber = "AB 123456", IsTrustee = true
                        }
                    },
                    Valutes = new List<Valute>{new Valute{ Id = "1", Name = "Bel rub", Rate = 2.1M, Code = "BLR"}}
                },
                new Client {
                    Id = "000000859",
                    Code = "111222",
                    Name = "Test name client 2",
                    CurrentWarehouseId = "3",
                    CanPayByCard = true,
                    CanPayByCash = true,
                    ShowTaxInvoiceDelivery = true,
                    DefaultTaxInvoiceDelivery = true,
                    IsRetail = true,
                    IsOrganizationManager = true,
                    IsCustomer = true,
                    IsSupplier = true,
                    ManagerData = new ManagerData {Email = "testManageremail1@itworks.com"},
                    IsDeliveryEnabled = true,
                    CurrentValute = "",
                    IsOperative = true,
                    AllowCustomOrders = true,
                    Contracts = new List<Contract>
                    {
                        new Contract
                        {
                            Id = "000000859-1", Name = "Contract 1 Prepay", Description = "Contract 1 description",
                            PayDelayDays = 0, PayDelayName = "Prepay"
                        },
                        new Contract
                        {
                            Id = "000000859-2", Name = "Contract 2", Description = "Contract 2 description", MaxSum = 100000,
                            PayDelayDays = 10, PayDelayName = "Pay Delay 10"
                        }
                    },
                    Contacts = new List<Contact>
                    {
                        new Contact
                        {
                            Id = "000000859-1", Name = "Contact Person 1", Comment = "Simple contact", DateFrom = DateTime.Today.AddDays(-1), Phone = "011111111111"
                        },
                        new Contact
                        {
                            Id = "000000859-2", Name = "Contact Person 2", Comment = "Trasted contact", DateFrom = DateTime.Today.AddDays(-1), DateTo = DateTime.Today.AddMonths(1),
                            Phone = "022222222222", DocumentNumber = "AB 123456", IsTrustee = true
                        }
                    },
                    Valutes = new List<Valute>{new Valute{ Id = "1", Name = "Bel rub", Rate = 2.1M, Code = "BLR"}}
                }
            };

        public List<Client> ManagedClients => _managedClients;
        private static readonly List<Client> _managedClients = new List<Client> {
                new Client {
                    Id = "101422",
                    Code = "101422",
                    Name = "Test name client 3",
                    CurrentWarehouseId = "1",
                    CanPayByCard = false,
                    CanPayByCash = false,
                    ShowTaxInvoiceDelivery = false,
                    DefaultTaxInvoiceDelivery = false,
                    IsRetail = false,
                    IsOrganizationManager = false,
                    IsCustomer = false,
                    IsSupplier = false,
                    ManagerData = new ManagerData {Email = "testManageremail1@itworks.com"},
                    IsDeliveryEnabled = false,
                    CurrentValute = "BLR",
                    IsOperative = false,
                    AllowCustomOrders = false,
                    Contracts = new List<Contract>
                    {
                        new Contract
                        {
                            Id = "101422-1", Name = "Contract 1 Prepay", Description = "Contract 1 description",
                            PayDelayDays = 0, PayDelayName = "Prepay"
                        },
                        new Contract
                        {
                            Id = "101422-2", Name = "Contract 2", Description = "Contract 2 description", MaxSum = 100000,
                            PayDelayDays = 10, PayDelayName = "Pay Delay 10"
                        }
                    },
                    Contacts = new List<Contact>
                    {
                        new Contact
                        {
                            Id = "101422-1", Name = "Contact Person 1", Comment = "Simple contact", DateFrom = DateTime.Today.AddDays(-1), Phone = "011111111111"
                        },
                        new Contact
                        {
                            Id = "101422-2", Name = "Contact Person 2", Comment = "Trasted contact", DateFrom = DateTime.Today.AddDays(-1), DateTo = DateTime.Today.AddMonths(1),
                            Phone = "022222222222", DocumentNumber = "AB 123456", IsTrustee = true
                        }
                    },
                    Valutes = new List<Valute>{new Valute{ Id = "1", Name = "Bel rub", Rate = 2.1M, Code = "BLR"}}
                }
            };

    }
}
