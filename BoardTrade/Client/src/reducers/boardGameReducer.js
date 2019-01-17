import { BOARD_GAME_FETCHING_SUCCESS } from '../actions/actionTypes'
import { combineReducers } from 'redux'

const initialState = {
  entities: []
}

export const entities = (state = initialState.entities, { type, entities }) => {
  switch (type) {
    case BOARD_GAME_FETCHING_SUCCESS:
      return entities
    default:
      return state
  }
}

const boardGameReducer = combineReducers({
  entities
})

export default boardGameReducer
