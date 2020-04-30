<?php



namespace Sabre\DAV\ExceptionNs;

use Sabre\DAV;

/**
 * InsufficientStorage.
 *
 * This Exception can be thrown, when for example a harddisk is full or a quota is exceeded
 *
 * @copyright Copyright (C) fruux GmbH (https://fruux.com/)
 * @author Evert Pot (http://evertpot.com/)
 * @license http://sabre.io/license/ Modified BSD License
 */
class InsufficientStorage extends DAV\Exception
{
    /**
     * Returns the HTTP statuscode for this exception.
     *
     * @return int
     */
    public function getHTTPCode()
    {
        return 507;
    }
}
