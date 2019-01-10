import { combineReducers } from 'redux'
import {
  JWT_TOKEN_FETCHING,
  JWT_TOKEN_FETCHING_SUCCESS
} from '../actions/actionTypes'

const initialState = {
  tokenIsFetching: false
}

const tokenIsFetching = (state = initialState.tokenIsFetching, { type }) => {
  switch (type) {
    case JWT_TOKEN_FETCHING:
      return true
    case JWT_TOKEN_FETCHING_SUCCESS:
      return false
    default:
      return state
  }
}

const loadersReducer = combineReducers({
  tokenIsFetching
})

export default loadersReducer
