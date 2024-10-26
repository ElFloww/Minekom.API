﻿namespace Minekom.Domain.Configuration
{
    public interface IOutputPort<in TUseCaseResponse>
    {
        void Handle(TUseCaseResponse p_Response);
    }
}