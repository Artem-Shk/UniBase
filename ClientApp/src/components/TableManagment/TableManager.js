import React, { useState, useEffect } from 'react';
import { Table } from 'reactstrap';
import axios from 'axios';
import fetchTableData from '../../actions'
import SearchBar from './SearchBar';
import { connect } from 'react-redux';

//TODO: delete repeated code for request
// function SearchBar() {
//   const handleKeyDown = (event) => {
//     if (event.keyCode === 13) {
      
//     }
//   }
//   return (
//     <div style={{ height: 46, left: 0 }}>
//       <input type='text' onKeyDown={handleKeyDown} />
//     </div>
//   )
// }

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
          <li key="1">Пункт 1</li>
          <li key="2">Пункт 2</li>
          <li key="3">Пункт 3</li>
        </ul>
      )}
    </div>
  );
}

function StudentTable({ name = 'Name' }) {
  const [persons, setPersons] = useState([]);
  const [fields, setFields] = useState([]);
  useEffect(() => {

    axios.get('studentdata/GetJsonTableRowData/Иван')
      .then(res => {
        const persons = res.data;
        setPersons(persons);
		const fields = Object.keys(persons[0]);
		setFields(fields);
		
      })
  }, []);
  return (
    <Table dark>
      <thead>
	  <tr >
	   {fields.map((element) => (
    			<th>{element}</th>
		))}
	  </tr>    
      </thead>
      <tbody>
        {persons.map((person, index) => (
		  <tr key = {index}>
			{fields.map((field)=>(
					<td>{person[field]}</td>)
				)
			}
		  </tr>))}
      </tbody>
    </Table>
  );
}
// const StudentTable = ({ data, searchTerm, fetchTableData }) => {
//   const [search, setSearch] = useState(searchTerm);

//   const handleSearchChange = (event) => {
//     const value = event.target.value;
//     setSearch(value);
//     fetchTableData(value);
//   };

//   return (
//     <div>
//       <input type="text" value={search} onChange={handleSearchChange} />
//       <table>
//         <thead>
//           <tr>
//             <th>Column 1</th>
//             <th>Column 2</th>
//             <th>Column 3</th>
//           </tr>
//         </thead>
//         <tbody>
//           {data.map((row) => (
//             <tr key={row.id}>
//               <td>{row.column1}</td>
//               <td>{row.column2}</td>
//               <td>{row.column3}</td>
//             </tr>
//           ))}
//         </tbody>
//       </table>
//     </div>
//   );
// };

const mapStateToProps = (state) => ({
  data: state.table.data,
  searchTerm: state.table.searchTerm,
});

const mapDispatchToProps = (dispatch) => ({
  fetchTableData: (searchTerm) => dispatch(fetchTableData(searchTerm)),
});

export default connect(mapStateToProps, mapDispatchToProps)(Table);

export function TableManager() {
  return (
    <div>
      <SearchBar />
      <div>
        <VerticalMenu />
        <StudentTable />
      </div>
    </div>
  );
}
  