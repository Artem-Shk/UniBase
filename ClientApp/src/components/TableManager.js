import React, { Component,useState } from 'react';
import { Table } from 'reactstrap';
function SearchBar(){
	return (
		<div style={{ height: 46 , left:0}}>
				<input />
			</div>
	)
}
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

 async  function  StudentTable() {
	const response = await  fetch('studentdata/GetJsonTableRowData/Иван').then((response) => {
		return (
			<div className="col">
			  <h1>Mi Casa</h1>
			  <p>This is my house y&apos;all!</p>
			  {response.map(home => <div>{home.name}</div>)}
			</div>
		  );
	  });
}
function  ComponentDidmount() {
	StudentTable();
}

  export class TableManager extends Component {
	render() {
	  return (
		<div>
			<SearchBar/>
		  <div>
			<VerticalMenu />
			<StudentTable></StudentTable>
		  </div>
		</div>
	  );
	}
  }

  