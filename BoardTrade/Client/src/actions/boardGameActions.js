import {
  BOARD_GAME_FETCHING,
  BOARD_GAME_FETCHING_SUCCESS,
  BOARD_GAME_FETCHING_ERROR
} from './actionTypes'

import http from '../utils/api'
import { normalize } from 'normalizr'
import { boardGameSchema } from '../utils/normalizr'

export const fetchBoardGames = () => async dispatch => {
  dispatch({ type: BOARD_GAME_FETCHING })

  const result = await http.get(`boardGame`)

  if (result && result.status === 200) {
    const normalized = normalize(result.data, [boardGameSchema])

    return dispatch({
      type: BOARD_GAME_FETCHING_SUCCESS,
      entities: normalized.entities.boardGame
    })
  }
  return dispatch({ type: BOARD_GAME_FETCHING_ERROR, ...result.data })
}
