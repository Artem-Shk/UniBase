import React, { Component,useState } from 'react';
function VerticalMenu() {
	const [isMenuOpen, setIsMenuOpen] = useState(false);
	
	const handleMenuClick = () => {
	  setIsMenuOpen(!isMenuOpen);
	};
	
	return (
	  <div>
		<button onClick={handleMenuClick}>Меню</button>
		{isMenuOpen && (
		  <ul>
			<li>Пункт 1</li>
			<li>Пункт 2</li>
			<li>Пункт 3</li>
		  </ul>
		)}
	  </div>
	);
  }
  
  export class TableManager extends Component {
	render() {
	  return (
		<div>
		  <div>
			<VerticalMenu />
		  </div>
		</div>
	  );
	}
  }

  