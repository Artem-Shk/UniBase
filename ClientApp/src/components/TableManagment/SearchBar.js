import React from 'react';
import { connect } from 'react-redux';

// const SearchBar = ({ searchQuery, setSearchQuery }) => {
//   const handleSearchChange = (event) => {
//     setSearchQuery(event.target.value);
//   };

//   return (
//     <input type="text" value={searchQuery} onChange={handleSearchChange} />
//   );
// };
function SearchBar() {
     const handleKeyDown = (event) => {
       if (event.keyCode === 13) {
        
       }
     }
     return (
       <div style={{ height: 46, left: 0 }}>
        <input type='text' onKeyDown={handleKeyDown} />
       </div>
    )
   }


// const mapStateToProps = (state) => ({
//   searchQuery: state.table.searchQuery,
// });

// const mapDispatchToProps = {
//   setSearchQuery,
// };

// export default connect(mapStateToProps, mapDispatchToProps)(SearchBar);

export default SearchBar;