import React from 'react';
import { connect } from 'react-redux';
import { fetchStudentsData } from '../../actions';
import store from '../../store';

function SearchBar() {
  const handleKeyDown = (event, name) => {
    if (event.keyCode === 13) {
      const searchValue = event.target.value;
      store.dispatch(fetchStudentsData(searchValue))
    }
  }
  return (
    <div style={{ height: 46, left: 0 }}>
      <input type='text' onKeyDown={handleKeyDown} />
    </div>
  )
}

export default SearchBar;