export const getBoardGamesEntities = state => state.boardGame.entities

export const getBoardGameEntity = (state, id) => {
  const boardGamesEntities = getBoardGamesEntities(state)
  return boardGamesEntities && boardGamesEntities[id]
}

export const getBoardGamesKeys = state => {
  const entities = getBoardGamesEntities(state)
  return entities && Object.keys(entities)
}

export const getBoardGameName = (state, id) => {
  const entity = getBoardGameEntity(state, id)
  return entity && entity.name
}

export const getBoardGameDescription = (state, id) => {
  const entity = getBoardGameEntity(state, id)
  return entity && entity.description
}

export const getBoardGameThumbnailUrl = (state, id) => {
  const entity = getBoardGameEntity(state, id)
  return entity && entity.thumbnailUrl
}
