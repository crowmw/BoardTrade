import { schema } from 'normalizr'

export const boardGameSchema = new schema.Entity(
  'boardGame',
  {},
  { idAttribute: 'id' }
)
