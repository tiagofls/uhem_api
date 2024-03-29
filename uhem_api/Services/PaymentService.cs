﻿using MySqlConnector;
using uhem_api.Dto;
using uhem_api.Interfaces.Repositories;
using uhem_api.Interfaces.Service;

namespace uhem_api.Services
{
    public class PaymentService : IPaymentService
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        MySqlConnection con = new MySqlConnection();

        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository) {
            _paymentRepository = paymentRepository;
        }

        public async Task<List<PaymentDto>> GetAll()
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _paymentRepository.GetAll(con);
                return res;
            }
        }

        public async Task<PaymentDto> GetPaymentById(int id)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _paymentRepository.GetPaymentById(con, id);
                return res;
            }
        }

        public async Task<bool> Post(PaymentDto data)
        {
            using (MySqlConnection con = SQLConnection.Connect())
            {
                var res = await _paymentRepository.Post(con, data);
                return res;
            }
        }
    }
}
