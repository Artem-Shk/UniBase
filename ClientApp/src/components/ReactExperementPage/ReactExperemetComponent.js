import React, { useState, useEffect } from 'react';
function ExperementForm() {
    let sobr = 'гутенТак'
    let [start, setStart] = useState("Классно")
    useEffect(()=>{
         document.getElementById('Gay').textContent = "pidrila";

    })

    return (
        <div>
             <button onClick={() => setStart("заебись")}>Еблан</button>
             <p> {start}</p>
             <p id='Gay'> {sobr}</p>
        </div>
       

    );
  }
export default ExperementForm;