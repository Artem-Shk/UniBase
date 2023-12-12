import React, { useState, useEffect } from 'react';
function ExperementForm() {
   
     let result = "";
      fetch('https://mmis-web.rudn-sochi.ru/api/Journals/Stat/Attendance?year=2023-2024&sem=1&formID=1', {
          method: 'GET',
          headers: {
            'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic2hha3Jpc2xhbm92LmEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdXJuYW1lIjoi0KjQsNC60YDQuNGB0LvQsNC90L7QsiDQkC7QoC4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9oYXNoIjoiIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc2lkIjoiMTI1MCIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvdXNlcmRhdGEiOiIyIiwidmVyaWZTdHJpbmciOiIiLCJuYmYiOjE2OTU4MTQxMDIsImV4cCI6MTY5NjQxODkwMiwiaXNzIjoiVmVkS2FmIiwiYXVkIjoiTU1JU0xhYiJ9.Q-Ci7Flf4w_zhBXPDQucOQVAkOn-cmpgw8WYa1Y_2Rk'
          },
        })
          .then(response => response.json())
          .then(data => {
            result = data
            console.log(data);
          })
          .catch(error => {
            console.error(error);
          });

    return (
        <div>
          {result.toString()}   
        </div>
       

    );
  }
export default ExperementForm;