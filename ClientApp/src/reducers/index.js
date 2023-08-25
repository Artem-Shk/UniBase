import { combineReducers } from 'redux';
import toTable from './tableReducer';




// rootReducer save table
const rootReducer = combineReducers({
  table: toTable,
 
});
console.log("Поставил редусер")
//it keywords needed for easer import
export default rootReducer;

