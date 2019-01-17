import { combineReducers } from 'redux'
import {
  JWT_TOKEN_FETCHING,
  JWT_TOKEN_FETCHING_SUCCESS,
  BOARD_GAME_FETCHING,
  BOARD_GAME_FETCHING_SUCCESS,
  BOARD_GAME_FETCHING_ERROR
} from '../actions/actionTypes'

const initialState = {
  tokenIsFetching: false,
  boardGamesIsFetching: false
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

const boardGamesIsFetching = (
  state = initialState.boardGamesIsFetching,
  { type }
) => {
  switch (type) {
    case BOARD_GAME_FETCHING:
      return true
    case BOARD_GAME_FETCHING_SUCCESS:
    case BOARD_GAME_FETCHING_ERROR:
      return false
    default:
      return state
  }
}

const loadersReducer = combineReducers({
  tokenIsFetching,
  boardGamesIsFetching
})

export default loadersReducer
