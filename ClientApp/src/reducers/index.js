import { combineReducers } from 'redux';
import toTable from './tableReducer';




// rootReducer save table
const rootReducer = combineReducers({
  table: toTable,
});
//it keywords needed for easer import
export default rootReducer;

