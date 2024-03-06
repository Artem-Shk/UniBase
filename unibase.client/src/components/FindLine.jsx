import React, { useState } from 'react';
import './FindLine.css'
function FindLine({ clickHandler, valueHook }) {
    const [findlineinputVal, SetInpuVal] = useState('');
    if (clickHandler) {
        
        valueHook(findlineinputVal)
    }
    return (
        <div className='FindLine'>
            <div className='search_container' >

                <input id="finline" type="text" className='search_container_text' onInput={evt => {
                    SetInpuVal(evt.target.value)
                }}/>
                <svg xmlns="http://www.w3.org/2000/svg" width="29" height="29" viewBox="0 0 29 29" fill="none">
                    <mask style={{ id: "mask0_378_8642", style: "mask-type:alpha", maskUnits: "userSpaceOnUse" }}>
                        <rect style={{ fill: "#D9D9D9" }} />
                    </mask>
                    <g mask="url(#mask0_378_8642)">
                        <path d="M23.6833 25.375L16.0708 17.7625C15.4667 18.2458 14.7719 18.6285 13.9865 18.9104C13.201 19.1924 12.3653 19.3333 11.4792 19.3333C9.28403 19.3333 7.42622 18.5731 5.90573 17.0526C4.38524 15.5321 3.625 13.6743 3.625 11.4792C3.625 9.28403 4.38524 7.42622 5.90573 5.90573C7.42622 4.38524 9.28403 3.625 11.4792 3.625C13.6743 3.625 15.5321 4.38524 17.0526 5.90573C18.5731 7.42622 19.3333 9.28403 19.3333 11.4792C19.3333 12.3653 19.1924 13.201 18.9104 13.9865C18.6285 14.7719 18.2458 15.4667 17.7625 16.0708L25.375 23.6833L23.6833 25.375ZM11.4792 16.9167C12.9896 16.9167 14.2734 16.388 15.3307 15.3307C16.388 14.2734 16.9167 12.9896 16.9167 11.4792C16.9167 9.96875 16.388 8.6849 15.3307 7.6276C14.2734 6.57031 12.9896 6.04167 11.4792 6.04167C9.96875 6.04167 8.6849 6.57031 7.6276 7.6276C6.57031 8.6849 6.04167 9.96875 6.04167 11.4792C6.04167 12.9896 6.57031 14.2734 7.6276 15.3307C8.6849 16.388 9.96875 16.9167 11.4792 16.9167Z" fill="#828282" />
                    </g>
                </svg>
            </div>
        </div>
    )
}
export default FindLine;