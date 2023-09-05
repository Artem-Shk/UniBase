import { combineReducers } from 'redux';
import toTable from './tableReducer';
import { faculiesToMenu } from './menuReducer'




// rootReducer save table
const rootReducer = combineReducers({
  table: toTable,
  menu: faculiesToMenu,
});
console.log("Поставил редусер")
//it keywords needed for easer import
export default rootReducer;

