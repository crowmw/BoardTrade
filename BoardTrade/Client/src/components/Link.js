import styled from 'styled-components'

export const Link = styled.a`
  color: ${({ theme }) => theme.colors.blueLight};
  cursor: pointer;
  text-decoration: none;

  :hover {
    text-decoration: underline;
  }
`

export default Link
