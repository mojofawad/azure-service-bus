import shared from '../eslint.shared.mjs';
import { createConfigForNuxt } from '@nuxt/eslint-config/flat';

export default createConfigForNuxt().prepend(...shared);
