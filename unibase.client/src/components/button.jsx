import React from 'react';
import './button.css'
function Button({ text, onClick }) {
	return (
		<button className="click-button" onClick={onClick}>
		  <p className="Button_text">{text}</p>
	  </button>
  );
}
export default Button;