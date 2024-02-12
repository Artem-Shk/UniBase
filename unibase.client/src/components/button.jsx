import React from 'react';
import './button.css'
function Button({ text }) {
  return (
	  <button className="click-button">
		  <p className="Button_text">{text}</p>
	  </button>
  );
}
export default Button;