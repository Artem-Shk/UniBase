﻿namespace UniBase.CORE.requests
{
    public class RequestResults
    {
        private Requester _requester = new Requester();

        public static string authToken;

        public RequestResults()
        {
            authToken = _requester.MMISAuthKey().Result;
        }
    }
}