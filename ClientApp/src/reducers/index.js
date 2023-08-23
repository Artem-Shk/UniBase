import { combineReducers } from 'redux';
import tableReducer from './tableReducer';
// rootReducer save table
const rootReducer = combineReducers({
  table: tableReducer,
});
//it keywords needed for easer import
export default rootReducer;

